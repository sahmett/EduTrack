# EduTrack
EduTrack, çeşitli eğitim kurslarını ve içeriklerini sunan bir web tabanlı platformdur.
Kullanıcılar, çeşitli kurslara kayıt olabilir, eğitim içeriklerine erişebilir ve eğitim süreçlerini takip edebilirler.

## Özellikler

- **Kurs Yönetimi**: Kurslar oluşturulabilir, güncellenebilir ve silinebilir. Her kursun adı, açıklaması, kategorisi, eğitmen tipi, kapasitesi, maliyeti ve süresi gibi özellikleri vardır.
- **Kategori Yönetimi**: Kurslar, farklı kategorilere ayrılabilir.
- **Kurs İçeriği**: Her kurs, birden fazla kurs içeriği ile ilişkilendirilebilir. Kurs içerikleri farklı türlerde olabilir (örneğin, video, makale, kitap).
- **Kullanıcı Kayıt ve Yönetimi**: Kullanıcılar platforma kayıt olabilir ve çeşitli kurslara kaydolabilirler.
- **Kullanıcı Kurs Kayıtları**: Kullanıcılar birden fazla kursa kayıt olabilir ve kurs kayıtları yönetilebilir.

## Teknoloji Yığını

- **Backend**: ASP.NET Core API
- **Frontend**:  ASP.NET Core MVC
- **Veritabanı**: PostgreSQL
- **ORM**: Entity Framework Core
- **Kullanıcı Yönetimi**: ASP.NET Core Identity

## Veritabanı İlişki Açıklamaları

- **Course ↔ Category**: Bir kategori birden fazla kursa sahip olabilir. Bir kurs yalnızca bir kategoriye ait olabilir.
- **Course ↔ CourseContent**: Bir kurs, birden fazla içeriğe sahip olabilir. Her içerik yalnızca bir kursa ait olabilir.
- **Course ↔ UserCourse ↔ User**: Bu ilişki many-to-many yapıdadır. Bir kullanıcı birden fazla kursa kayıt olabilir ve bir kurs birden fazla kullanıcıya sahip olabilir.
- **User ↔ UserCourse**: Bir kullanıcı birden fazla kurs kaydına sahip olabilir. Her kurs kaydı yalnızca bir kullanıcıya ait olabilir.


