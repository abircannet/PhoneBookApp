# PhoneBook Microservice App
Contact ve Contact details varlıklarının CRUD operasyonları ile raporlama gereksinimlerini karşılamak üzere geliştirilmiş örnek microservice uygulamasıdır.
## Ön Gereklilikler
Repository clone yada download ediniz. Yerel bilgisayarınızda projeyi çalıştırmanız için Visual Studio 2022, Microsoft Sql Server ve RabbitMQ kurulumu gerektirir.
## Message Broker
Projede kullanılan RabbitMQ için local kurulum yanı sıra docker üzerinde de çalıştırabilirsiniz.
```
docker run  --hostname my-rabbit --name myrabbit  -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
## Microsoft SQL Server
MSSQL kurulumunuza uygun olarak **Cdr.ReportMicroservice.RestfullAPI** ve **Cdr.ContactMicroservice.RestfullAPI** projelerinin **appSettingsjson** dosyalarındaki **ConnectionString** nodelarını düzenleyiniz.

## Projeyi Çalıştırma

Proje başlatma ayarlarınızdan Multiple Startup Projects seçeneğini seçerek **Cdr.ReportMicroservice.RestfullAPI** ve **Cdr.ContactMicroservice.RestfullAPI** projelerini **Start** ayarlayın.
