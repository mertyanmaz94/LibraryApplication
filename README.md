# Library Uygulaması (Kütüphane Görevlisi İçin Kitap ve Okuyucu Yönetim Paneli) <br/>
**Library Uygulaması**, clean architecture ve .Net Core Mvc teknolojilerini kullanarak bir kütüphane görevlisinin  kütüphanedeki kitap alışverişinin ve bunların kaydının en doğru ve hızlı bir şekilde yapılabilmesi için hazırlanmıştır. 
## Ana Özellikler: <br/>
•	**Kullanıcı dostu arayüz** <br/>
• **Modüler Yapı :**  Proje, modüler bir yapıya sahip olduğu için, geliştiriciler ihtiyaçlarına göre yeni özellikler ekleyebilir veya mevcut özellikleri çıkarabilir. <br/>
•	**Esnek yapı:** Projenin esnek yapısı sayesinde, geliştiriciler farklı teknolojilerle entegre edebilir ve uygulamanın özelliklerini özelleştirebilir.  <br/>
## Projenin Katmanları
•	**Domain Katmanı :** Bu katman bizim çekirdek katmanımızdır. Bu katman diğer hiçbir katmana bağımlı değildir. Bu katmanda business entitylerimiz bulunur ve bunlar basit ve küçük sınıflardır.  <br/>
•	**Applicaiton Katmanı :** Sadece Domain katmanına bağımlıdır ve oradaki bileşenleri kullanarak business logic’i oluşturur. Bu iki katman ile uygulamamızı oluştururuz. Bu katmanda verileri nasıl saklıyacağımızın, client ile nasıl iletişime geçeceği gibi konuları soyut bir şekilde oluşturup diğer üst katmanlarda bunları gerekiyorsa implemente edip kullanırız. O yüzden bu katmanda Interface, Model, Logic, Command/Queries, Validators/ Exceptions’ larımız bulunabilir.  <br/>
•	**Infrastructure :** Bu katmanda application katmanında ki Interfaceleri implemente ederek veritabanı operasyonların implementasyonlarını yaparız. Projemizin hiçbir katmanı bu katmana bağımlı değildir.  <br/>
•	**Presentation :** Bu katman kullanıcının uygulama ile iletişime geçtiği katmandır. Bu katman en üst katmanıdır bu yüzden hiç bir katman bu katmana bağımlı değildir.  <br/>
## Proje Oluşturulmaya Başlamadan Nasıl Yol İzlendi?
**1)**	Vaka Dökümanı detaylıca incelendi.  <br/>
**2)**	Object Orianted Programlama ile geliştirme yapılacağı için istekler doğrultusunda oluşturulması gereken nesnelere ve nesneler arasındaki ilişkilere karar verildi.  <br/>
**3)**	Oluşturulacak sayfaların taslakları oluşturulup veritabanı üzerinde yapılacak işlemlere karar verildi.  <br/>

