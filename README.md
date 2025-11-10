_Mini Online Store - Project Shartlari_
  1. **Project nomi:** Mini Online Store
  2. **Maqsad:** ASP.NET MVC asosida ko'p funksiyali mini onlayn do'kon yaratish, har bir funksiya alohida
                  page bilan ishlaydi.
  
  **3. Controllers va Actions:**
HomeController
Index() → Home page
About() → About page
ProductsController
List() → Products ro'yxati page
Details(int id) → Mahsulot tafsilotlari page
AccountController
Login() → Login page
Register() → Ro'yxatdan o'tish page
SplashController (ixtiyoriy)
Index() → Splash screen page
  
  **4. Models:**
Product: Id, Name, Price
User: Username, Password
  
  **5. Views:**
Har bir Action uchun alohida .cshtml fayl yaratish
Views/Home/Index.cshtml
Views/Home/About.cshtml
Views/Products/List.cshtml
Views/Products/Details.cshtml
Views/Account/Login.cshtml
Views/Account/Register.cshtml
Views/Splash/Index.cshtml (ixtiyoriy)
  
  **6. Routing:**
     URL                   Page
/Splash/Index          Splash Screen (ixtiyoriy)
/Home/Index            Home Page
/Home/About            About Page
/Products/List         Products List
/Products/Details/1    Product Details (id=1)
/Account/Login         Login Page
/Account/Register      Register Page
  
  **7. Qo'shimcha tavsiyalar:**
Har bir view oddiy matn va title bilan bo'lsin.
Views ichida linklar qo'shib page'lar orasida navigatsiya qilish mumkin.
Splash screen vaqtinchalik bo'lib, 2–3 soniyadan keyin Home page ga yo'naltirilsin.
Keyinchalik loyihaga "Add to Cart", "Search" va boshqa funksiyalar qo'shilishi mumkin.
  
  **8. Project struktura misoli:**
MiniStore/
 ├─ Controllers/
 │ └─ HomeController.cs
 │ └─ ProductsController.cs
 │ └─ AccountController.cs
 │ └─ SplashController.cs (ixtiyoriy)
 ├─ Models/
 │ └─ Product.cs
 │ └─ User.cs
 ├─ Views/
 │ ├─ Home/
 │ │ ├─ Index.cshtml
 │ │ └─ About.cshtml
 │ ├─ Products/
 │ │ ├─ List.cshtml
 │ │ └─ Details.cshtml
 │ ├─ Account/
 │ │ ├─ Login.cshtml
 │ │ └─ Register.cshtml
 │ └─ Splash/
 │ └─ Index.cshtml (ixtiyoriy)
 ├─ wwwroot/
 │ └─ css/
 │ └─ js/
 ├─ appsettings.json
 └─ Program.cs
