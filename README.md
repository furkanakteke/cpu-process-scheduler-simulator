# CPU Process Scheduling & Multi-Queue Simulator (Windows Forms)

Bu proje, İşletim Sistemleri (Operating Systems) mimarisinde yer alan **İşlem Zamanlama (Process Scheduling)** ve **Çoklu Öncelik Kuyrukları (Multi-Level Priority Queues)** mantığını görselleştirmek amacıyla C# Windows Forms mimarisiyle geliştirilmiş interaktif bir simülatördür.

Uygulama; dinamik bağlı liste (linked list) altyapısı üzerine inşa edilmiş 3 farklı öncelik hattını (`P1`, `P2`, `P3`) zamana dayalı (`Timer` ve `TrackBar`) olarak asenkron şekilde simüle eder.

---

## 🧠 Mimari Yapı ve Çalışma Prensibi

Simülatör, arka planda .NET'in hazır koleksiyon kütüphanelerini (Queue, Stack, List vb.) kullanmak yerine, tamamen ham `Node` ve `LinkedList` referanslarıyla geliştirilmiş özel veri yapılarını koordine eder:

1. **Performans Odaklı Kuyruk Yapısı (`O(1)`):** Sona eleman ekleme işlemlerinde tüm listeyi baştan sona dönmek (`while` döngüsü maliyeti - $O(n)$) yerine, `tail` (kuyruk sonu) göstericisi kullanılarak eklemeler doğrudan **$O(1)$ zaman karmaşıklığı** ile optimize edilmiştir.
2. **Çoklu Görev (Multi-Queue) Yönetimi:** `P1`, `P2` ve `P3` olarak adlandırılan 3 farklı öncelik sınıfına sahip işlem hattı (process thread simülasyonu) oluşturulmuştur.
3. **Dinamik Hız ve Zaman Kontrolü (`TrackBar`):** Her işlem hattının çalışma frekansı ve önceliği, kullanıcı tarafından `TrackBar` elementleri üzerinden anlık (`Timer.Interval`) olarak manipüle edilebilmektedir.
4. **Canlı İzleme Paneli (`UpdateTextBox`):** Arka planda kuyruklara giren (`enQueue`) ve işlem tamamlandıkça çıkan (`deQueue`) rastgele üretilmiş proses verileri `StringBuilder` mimarisiyle `TextBox` ve `ListBox` nesnelerine anlık olarak render edilir.

---

## 🚀 Proje Kazanımları

* İşletim sistemlerinin temel proses yönetim döngüsünün (CPU Scheduling) kavranması.
* Zamana bağlı (Event/Timer Driven) asenkron arayüz süreçlerinin yönetilmesi.
* Hazır kütüphaneler olmadan, tamamen gösterici (pointer/referans) tabanlı veri yapılarının asenkron simülasyonlara entegre edilmesi.

---

## 🛠️ Teknolojiler

* **Dil:** C#
* **Arayüz:** .NET Windows Forms
* **Konsept:** CPU Scheduling Teorisi, Kuyruk (Queue) Veri Yapısı, Asenkron Zaman Yönetimi (Timers), Kod Optimizasyonu.
