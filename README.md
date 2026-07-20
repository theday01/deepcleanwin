# <p align="center"><img src="logo.png" alt="DeepClean Pro Logo" width="128"/><br>DeepClean Pro</p>

<p align="center">
  <img src="https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows" alt="Platform: Windows" />
  <img src="https://img.shields.io/badge/Language-C%23%20/.NET%208.0-239120?style=for-the-badge&logo=c-sharp" alt="Language: C# / .NET 8" />
  <img src="https://img.shields.io/badge/Framework-Windows%20Forms-512BD4?style=for-the-badge&logo=.net" alt="Framework: WinForms" />
  <img src="https://img.shields.io/badge/Aesthetic-Hacker%20Green-00FF00?style=for-the-badge" alt="Theme: Hacker Green" />
  <img src="https://img.shields.io/badge/Version-2.0-brightgreen?style=for-the-badge" alt="Version: 2.0" />
</p>

---

## 🌟 Executive Summary / نظرة عامة
**DeepClean Pro** is an ultra-premium, high-performance system maintenance and diagnostic utility tailored for Windows power users. Combining a sophisticated **hacker aesthetic UI** (vibrant green text, scrolling terminal logs, and live status feedback) with robust enterprise-grade cleanup mechanics, DeepClean Pro keeps your system operating at peak performance. 

Unlike standard optimization tools, DeepClean Pro prioritizes **safety first**—automatically creating system restore points and supporting a comprehensive **Simulation Mode (Dry Run)** so you can preview optimization gains risk-free. It also integrates real-time hardware diagnostics to assess hard disk status, temperatures, and sequential read/write performance.

---

# 🇬🇧 English Documentation

## 🚀 Key Features

### 1. Advanced System Cleaner
A fully automated, zero-interaction engine resembling tools like CCleaner but refined for absolute safety and deep scanning:
*   **System Temp & Prefetch:** Thoroughly purges user/system temporary folders and execution prefetch logs.
*   **Windows Update Cache:** Safely stops background services (`wuauserv`, `bits`), flushes the SoftwareDistribution cache, and restarts them.
*   **Windows Disk Cleanup integration:** Automates the native Windows cleanup tool using optimized state flags for maximum space recovery.
*   **Event Logs & Diagnostics:** Scans and safely flushes deep Windows Event Logs and legacy log files.
*   **Recycle Bin & Crash Dumps:** Purges crash dumps (WER reports) and empties the system drive's recycling bin.
*   **DNS & Delivery Optimization Cache:** Flushes the DNS lookup cache and Windows Update delivery optimization remnants.
*   **Quick Access & Privacy History:** Erases MRUs (Most Recently Used), Typed Paths, Paint/Wordpad histories, Jump Lists, and UserAssist execution statistics.
*   **Multi-Browser Cleanup:** Clears browser caches across Chrome, Edge, Brave, Opera, and Firefox profiles.
*   **Popular App Caches:** Safely removes bloated cache files from Discord, Slack, Spotify, and Steam.
*   **System Image Optimization (DISM):** Automates the deep `/StartComponentCleanup` to trim the size of the Windows Side-by-Side (SxS) folder.

### 2. Live Hard Disk Diagnostics
Deep diagnostic reports built with C# and PowerShell integrations:
*   **Physical Disk Inspection:** Analyzes Friendly Name, Media Type (SSD/HDD), Health Status, Operational Status, and total read/write error logs.
*   **Dual-Layer Temperature Fallback:**
    1.  *Primary:* Queries modern PowerShell Storage Reliability Counters.
    2.  *Fallback (SATA/Legacy):* Direct WMI polling of `MSStorageDriver_ATAPISmartData` attribute 194 (S.M.A.R.T. raw temperature data).
*   **Volume & Storage Capacity Analysis:** Breaks down free and occupied space percentages for every mounted volume.
*   **Sequential I/O Speed Benchmark:** Executes a real-time sequential 64MB read/write test using non-compressible random buffers to evaluate exact drive speeds.

### 3. Ultimate Safety Mechanisms
*   **🛡️ Mandatory Restore Point:** Automatically triggers a native Windows System Restore Point called `DeepCleanPro Auto-Backup` prior to performing any live modification.
*   **🧪 Simulation Mode (Dry Run):** Fully test-drive the application! Toggle simulation on to safely output exactly what files and registry records *would* be deleted, without altering a single byte on your drive.

---

## 🛠️ Architecture & Technical Design

The codebase is engineered with strict separation of concerns, utilizing modern asynchronous design patterns:

```
├── Program.cs                 # Main Application Bootstrapper
├── Form1.cs                   # UI Event Handlers, Animations, and Worker Dispatching
├── Form1.Designer.cs          # UI Definition (RichTextBox, Progress Bars, Checkboxes)
├── Cleaner.cs                 # Deep Cleanup Engine (Automation, File/Registry Purging)
├── DiskHealthChecker.cs       # Diagnostic Engine (PowerShell & WMI queries, Benchmarking)
├── DeepCleanPro.csproj        # Build Configuration targeting .NET 8.0 Windows
├── app.manifest               # Execution manifest requesting Administrator Privileges
├── build.bat                  # Local release compiler script
├── download_prerequisites.ps1 # Offline dependency retriever
└── setup.iss                  # Inno Setup Script for offline deployment
```

### Flowchart of Execution
```
[User Clicks Initiate Cleanup]
              │
              ▼
   [Simulation Mode Active?]
     ├── YES ──► Log actions to UI terminal (No files touched)
     └── NO  ──► 1. Trigger Windows Restore Point (Checkpoint-Computer)
                 2. Pause background system services
                 3. Run cleanups sequentially (Temp, Prefetch, Registry, Caches)
                 4. Execute cleanmgr.exe and dism.exe
                 5. Resume background services
```

---

## 📦 How to Build & Package

### Prerequisites
*   Windows 10 / 11 (64-bit recommended)
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
*   [Inno Setup 6+](https://jrsoftware.org/isdl.php) (to compile the `.exe` installer)

### Step 1: Download Dependencies
Run the PowerShell script to download the offline installer bundles of the .NET Desktop Runtimes (x86 & x64):
```powershell
PowerShell -ExecutionPolicy Bypass -File download_prerequisites.ps1
```
*(This downloads the offline installers inside a `/Prerequisites` directory, ensuring proper delivery even without internet access during client setup).*

### Step 2: Build the Application
Double-click `build.bat` or run:
```batch
build.bat
```
This builds the C# solution in `Release` mode. The compiled output will be generated inside:
`bin\Release\net8.0-windows\`

### Step 3: Compile the Installer
Open `setup.iss` inside Inno Setup Compiler and click **Compile** (F9). This generates the bundled offline setup file `DeepCleanPro_Setup_v2.0.exe` in the Output directory.

---

## 🛡️ Best Practices & Guidelines
1.  **Run as Administrator:** DeepClean Pro requires elevated privileges to access prefetch files, stop services, clear Event Logs, and query hardware status. The application is packaged to request Administrator privilege automatically.
2.  **Simulation first:** We recommend running a dry run (Simulation Mode checked) on a new device to safely audit what will be removed.

---

<br>

# 🇸🇦 الترجمة العربية الكاملة / Arabic Documentation

## 🌟 ملخص تنفيذي
برنامج **DeepClean Pro** هو أداة متكاملة وفائقة الأداء لصيانة وتشخيص نظام التشغيل Windows، مصممة خصيصاً للمستخدمين المحترفين الذين يبحثون عن أقصى درجات الفاعلية والتحكم. يتميز البرنامج بواجهة مستخدم مستوحاة من **جماليات الهاكرز المتقدمة** (نصوص خضراء متوهجة، سجلات برمجية فورية، ومؤشرات تفاعلية ذكية) مع محرك تنظيف قوي وموثوق يرتقي بأداء جهازك إلى الحدود القصوى.

على عكس أدوات التنظيف التقليدية، يضع برنامج DeepClean Pro **الأمان في المقام الأول**؛ حيث يقوم تلقائيًا بإنشاء نقاط استعادة النظام قبل أي عملية تنظيف فعلية، كما يدعم **وضع المحاكاة الكامل (Simulation Mode)** لمعاينة النتائج بأمان تام دون حذف أي ملف. بالإضافة إلى ذلك، يتضمن البرنامج نظام تشخيص فوري ومتقدم للتحقق من سلامة الأقراص الصلبة، درجات حرارتها، وسرعات القراءة والكتابة الفعلية.

---

## 🚀 الميزات الرئيسية

### 1. منظف النظام المتقدم
محرك آلي بالكامل ينظف النظام بعمق دون أي تدخل يدوي، مع حماية تامة لملفاتك الأساسية:
*   **ملفات النظام المؤقتة والـ Prefetch:** إزالة كاملة لملفات المستخدم المؤقتة وسجلات التشغيل المسبق لزيادة سرعة استجابة التطبيقات.
*   **ذاكرة تحديثات Windows:** إيقاف خدمات التحديث مؤقتاً (`wuauserv`, `bits`)، وتفريغ مخزن التنزيلات المؤقت، ثم إعادة تشغيل الخدمات بسلاسة.
*   **تكامل مع أداة تنظيف الأقراص الرسمية:** التحكم البرمجي بـ Windows Disk Cleanup لتنظيف عميق لكافة ملفات النظام المهملة.
*   **سجلات الأحداث والتصحيح:** مسح آمن لملفات سجل الأحداث (Event Logs) والملفات التشخيصية المتراكمة.
*   **سلة المهملات وتقارير الأخطاء:** تفريغ سلة مهملات القرص الرئيسي ومسح تقارير الانهيارات البرمجية (Crash Dumps).
*   **ذاكرة الـ DNS وتوصيل التحديثات:** تفريغ كاش الـ DNS وتحسين ملفات Delivery Optimization لشبكة أسرع.
*   **الخصوصية والملفات الأخيرة:** مسح قوائم الوصول السريع، سجلات الرسام والدفتر، والمسارات المكتوبة وسجلات تشغيل البرامج في الريجستري.
*   **تنظيف متصفحات الإنترنت:** تفريغ الكاش لمتصفحات Chrome, Edge, Brave, Opera, و Firefox.
*   **كاش التطبيقات الشهيرة:** إزالة تراكمات الكاش لبرامج Discord, Slack, Spotify, و Steam.
*   **تحسين صورة النظام (DISM):** تنظيف مستودع مكونات Windows Side-by-Side (SxS) لتقليص حجم النظام الفعلي.

### 2. تشخيص فوري وذكي للأقراص الصلبة
تقارير تشخيصية شاملة مبنية على تكامل متطور بين لغة C# وسكربتات PowerShell:
*   **معلومات الأقراص الفعلية:** عرض اسم القرص، نوعه (SSD أو HDD)، حالته التشغيلية، ومجموع أخطاء القراءة والكتابة.
*   **نظام مزدوج لقراءة درجة الحرارة:**
    1.  *الطريقة الحديثة:* استخدام عدادات الموثوقية الخاصة بـ PowerShell.
    2.  *الطريقة الاحتياطية (لأقراص SATA القديمة):* الاستعلام المباشر عبر WMI لبروتوكول S.M.A.R.T (خاصية رقم 194).
*   **تحليل مساحات التخزين:** تفصيل دقيق للمساحة الحرة والمستخدمة لجميع الأقسام والبارتشنز.
*   **اختبار سرعة الأقراص:** إجراء اختبار قراءة وكتابة حقيقي لـ 64 ميجابايت من البيانات العشوائية غير القابلة للضغط لمعرفة الأداء الفعلي الفوري لقرصك.

### 3. آليات الأمان القصوى
*   **🛡️ نقطة استعادة إجبارية:** يقوم البرنامج فوراً بإنشاء نقطة استعادة نظام تحت اسم `DeepCleanPro Auto-Backup` قبل البدء في أي عملية تنظيف فعلية لحماية نظامك ضد أي طارئ.
*   **🧪 وضع المحاكاة (بدون حذف فعلي):** يتيح لك اختبار البرنامج بالكامل بسلامة مطلقة؛ حيث يعرض لك السجلات والملفات التي كان سيتم حذفها دون تعديل بت واحد على قرصك.

---

## 🛠️ البنية البرمجية والتصميم التقني

تم تصميم المشروع وهندسته بفصل تام بين المهام البرمجية والاعتماد على أحدث تقنيات المعالجة غير المتزامنة (Asynchronous Tasks):

```
├── Program.cs                 # نقطة انطلاق التطبيق الرئيسية
├── Form1.cs                   # معالجة واجهة المستخدم، الحركة، وإرسال المهام
├── Form1.Designer.cs          # تصميم الواجهة والأزرار ومربعات الخيارات
├── Cleaner.cs                 # محرك التنظيف العميق (الملفات، الخدمات، والريجستري)
├── DiskHealthChecker.cs       # محرك التشخيص (سرعات الأقراص، درجات الحرارة عبر PowerShell و WMI)
├── DeepCleanPro.csproj        # ملف إعدادات المشروع واستهداف .NET 8.0 Windows
├── app.manifest               # ملف طلب صلاحيات المسؤول للبرنامج
├── build.bat                  # سكربت تجميع المشروع المحلي لإصدار Release
├── download_prerequisites.ps1 # سكربت تحميل ران تايم .NET أوفلاين
└── setup.iss                  # ملف تجميع المثبت الذاتي عبر Inno Setup
```

### مخطط تدفق العمليات
```
[المستخدم يضغط على بدء التنظيف]
              │
              ▼
    [هل وضع المحاكاة مفعل؟]
     ├── نعم ──► طباعة العمليات في السجل فقط دون المساس بأي ملف
     └── لا  ──► 1. إنشاء نقطة استعادة النظام (Checkpoint-Computer)
                 2. إيقاف خدمات التحديث الخلفية مؤقتاً
                 3. تشغيل مهام التنظيف بالتتابع (الملفات المؤقتة، الريجستري، إلخ)
                 4. استدعاء أدوات النظام cleanmgr.exe و dism.exe
                 5. إعادة تشغيل الخدمات الخلفية
```

---

## 📦 كيفية بناء وتجميع المشروع

### المتطلبات الأساسية
*   نظام تشغيل Windows 10 / 11 (يفضل نواة 64 بت)
*   حزمة التطوير [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
*   برنامج التثبيت [Inno Setup 6+](https://jrsoftware.org/isdl.php) (لإنتاج ملف التثبيت النهائي)

### الخطوة 1: تحميل التبعيات والملحقات
قم بتشغيل سكربت PowerShell لتحميل حزم التثبيت الأوفلاين لبيئة عمل .NET (لنواة x86 و x64):
```powershell
PowerShell -ExecutionPolicy Bypass -File download_prerequisites.ps1
```
*(يقوم هذا بتحميل التثبيتات دون إنترنت داخل مجلد `/Prerequisites` لضمان عمل البرنامج حتى في الأجهزة غير المتصلة بالشبكة).*

### الخطوة 2: بناء وتصدير التطبيق
قم بتشغيل ملف `build.bat` بالضغط المزدوج أو عبر سطر الأوامر:
```batch
build.bat
```
سيقوم هذا ببناء المشروع بلغة C# بوضع `Release`. ستجد الملفات المصدرة في المسار التالي:
`bin\Release\net8.0-windows\`

### الخطوة 3: تجميع ملف التثبيت النهائي
افتح ملف `setup.iss` بواسطة برنامج Inno Setup Compiler واضغط على زر **Compile** (أو F9). سيتم إنتاج ملف التثبيت الشامل والأوفلاين `DeepCleanPro_Setup_v2.0.exe` داخل مجلد Output.

---

## 🛡️ إرشادات ونصائح الاستخدام
1.  **التشغيل كمسؤول:** يتطلب برنامج DeepClean Pro صلاحيات المسؤول الكاملة للوصول لملفات النظام، إيقاف الخدمات، مسح سجل الأحداث، والاستعلام الذكي عن الأقراص. البرنامج مصمم ليطلب هذه الصلاحية تلقائياً.
2.  **المحاكاة أولاً:** ننصح بشدة بتشغيل وضع المحاكاة عند تجربة البرنامج لأول مرة للتحقق من الملفات المستهدفة بدقة وأمان.

---

## 👥 Developed By / تطوير
*   **EagleShadow - HAMZA SAADI**
*   **Copyright 2026**

---

<p align="center">
  <img src="logo.png" alt="DeepClean Pro Footer Logo" width="96"/><br>
  <i>DeepClean Pro - Your ultimate companion for a pristine and healthy Windows environment.</i><br>
  <i>DeepClean Pro - رفيقك الأمثل لبيئة عمل ويندوز نظيفة وصحية تماماً.</i>
</p>
