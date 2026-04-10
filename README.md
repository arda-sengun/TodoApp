# .NET Core Web API - CRUD Mastery Project

Bu proje, .NET Core Web API kullanarak temel CRUD operasyonlarını ve RESTful mimariyi içselleştirmek amacıyla geliştirilmiştir.

## 🚀 Gelişim Süreci

Bu repo, "kas hafızası" oluşturma odaklı bir öğrenme sürecini yansıtmaktadır:

1. **Aşama (Iteration 1):** Temel Controller yapısı, Dependency Injection ve in-memory List tabanlı veri yönetimi kurgulandı.
2. **Aşama (Iteration 2):** Kod bakmadan tekrar yazılarak mimari yapı (Routing, HTTP Verbs, Status Codes) pekiştirildi.
3. **Aşama (Iteration 3):** Entity Framework Core entegrasyonu tamamlandı. In-memory list yapısından SQL Server veritabanına geçildi. DbContext, Migration ve async CRUD operasyonları uygulandı.

## 🛠 Kullanılan Teknolojiler

* **.NET 8.0** (Web API)
* **ASP.NET Core Controllers**
* **Entity Framework Core 8.0** (SQL Server)
* **Swagger / OpenAPI** (API Test ve Dokümantasyon)

## 📌 Öğrenilen Kazanımlar

* REST ilkelerine uygun endpoint tasarımı.
* `IActionResult` ile doğru HTTP durum kodlarının dönülmesi.
* DbContext ve Migration ile veritabanı yönetimi.
* Async/await ile asenkron veri erişimi.
* Dependency Injection ile DbContext kullanımı.

---
*Bu proje bir eğitim serisinin parçasıdır. Her commit, bir önceki adımın üzerine inşa edilen yeni bir yetkinliği temsil eder.*
