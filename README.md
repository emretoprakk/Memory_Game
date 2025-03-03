# 🚀 Arızalı Cihaz Takip Backend - Proje Kurulum Rehberi

Bu proje, **ASP.NET Core** tabanlı çok katmanlı bir backend şablonudur. **Kendi belirlediğiniz proje adıyla** kullanmak için aşağıdaki adımları takip edebilirsiniz.  

---

## 📌 Proje Kurulumu  

### 🔹 **1. Projeyi Klonlayın**  
Öncelikle projeyi GitHub’dan bilgisayarınıza klonlayın:  
```sh
git clone https://github.com/SoftDev-modules/dotnet-base-project.git
cd dotnet-base-project
``` 

### 🔹 2. Şablon Yapısını Oluşturun
Proje kök dizinine .template.config klasörü ekleyin:
```sh
mkdir .template.config
```
Daha sonra .template.config/template.json dosyasını oluşturup aşağıdaki içeriği ekleyin:
```sh
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Emre Toprak",
  "classifications": [ "Web", "API", "Class Library" ],
  "identity": "ArizaliCihazTakip.Template",
  "name": "Arızalı Cihaz Takip Backend Project Template",
  "shortName": "arizalicihaz",
  "sourceName": "BaseProject",
  "preferNameDirectory": true,
  "tags": {
    "language": "C#",
    "type": "solution"
  }
}
```
sourceName alanı, eski proje adıyla (BaseProject) eşleşmelidir. Yeni projede bu isim otomatik değiştirilecektir.

### 🔹 3. Şablonu Yükleyin ve Doğrulayın
```sh
dotnet new install ./
dotnet new list
```

### 🔹 4. Yeni Proje Dizininizi Ayarlayın
Yeni projeyi oluşturmak istediğiniz dizine gidin:
```sh
cd C:\Users\90536\Desktop  # Örneğin masaüstüne kurulum
```
### 🔹 5. Yeni Projeyi Oluşturun
```sh
dotnet new arizalicihaz -n ArizaliCihazTakipBackend
```
### 🔹 6. Projeyi Çalıştırın ve Test Edin
```sh
cd ArizaliCihazTakipBackend
dotnet build
dotnet run
```
