# Utilities (.NET 8.0 Class Library)

Bu proje, .NET 8.0 ile geliştirilmiş, yaygın olarak kullanılan yardımcı sınıfları ve genel amaçlı kod tekrarlarını azaltmaya yönelik bileşenleri içeren bir sınıf kütüphanesidir. `Utilities` kütüphanesi, projelerinizde tekrar kullanılabilirliği artırmak ve kodunuzu daha okunabilir hale getirmek amacıyla oluşturulmuştur.

## 📁 Proje Yapısı

```
Utilities/
├── Constants/     # Sabit değerlerin tanımlandığı sınıflar
├── Extensions/    # Extension metodlar (genişletmeler)
├── Generics/      # Generic yapılar ve soyutlamalar
├── Helpers/       # Yardımcı sınıflar ve statik fonksiyonlar
```

## 🔧 Kullanım Senaryoları

### Generics
Ortak soyutlamaları ve generic yapıları kullanarak daha esnek ve yeniden kullanılabilir çözümler geliştirin.

```csharp
public class Result<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}
````

### Extensions

.NET türlerine özel genişletmelerle daha temiz ve okunabilir kod yazın.

```csharp
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);
}
```

### Helpers

Projelerinizde sık kullandığınız işlemler için hazır yardımcı sınıflar.

```csharp
public static class DateHelper
{
    public static bool IsWeekend(DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
}
```

### Constants

Ortak kullanılan sabit değerleri merkezi bir yerde tutarak kod tekrarı ve hardcoded değerleri ortadan kaldırın.

```csharp
public static class AppConstants
{
    public const string DefaultDateFormat = "yyyy-MM-dd";
}
```

## 🚀 Hedefler

* Kod tekrarını en aza indirmek
* Genişletilebilir ve bakımı kolay bir yardımcı kütüphane oluşturmak
* Proje genelinde kullanılabilir soyutlamalar sağlamak
* Açık kaynak ve katkıya açık olmak

## 🛠️ Gereksinimler

* .NET 8.0 SDK
* C# 12 veya üzeri

## 📦 Kurulum

Projeye NuGet olarak eklemek (yayınladıysanız):

```bash
dotnet add package Utilities
```

Yoksa doğrudan çözüm (solution) dosyanıza referans olarak ekleyin:

```xml
<ProjectReference Include="..\Utilities\Utilities.csproj" />
```

## 📄 Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına göz atın.

---

> Her türlü öneri, katkı ve geri bildirim için lütfen [issue](https://github.com/kullaniciadi/Utilities/issues) açmaktan çekinmeyin.
