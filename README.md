# BattleshipGame
+ Yaptığım proje Battleship oyununun online oynanılabilen bir uygulamasıdır.
+ Bu oyun iki kişi ile oynanılan ve amacı rakibin tüm gemilerini batırmak olan bir oyundur.
+ İlk olarak oyuncular gemilerini 10x10 hücre olan oyun tablosuna dikey ve yatay olarak yerleştirmelidir.
+ Oyunun benim versiyonumda:
-5 hücre kaplayan 1xCarrier
-4 hücre kaplayan 1xBattleship
-3 hücre kaplayan 1xCruiser
-2 hücre kaplayan 2xDestroyer olmak üzere 5 adet gemi var.
+Daha sonra sıra ile rakip gemilerin yerlerini görmeden,tahmin etmeye çalışarak atış yapılır.
+Oyuncu, rakip gemilerden birini vurduğunda hücre kırmızıya, ıskaladığında yeşile döner.
+Rakip gemilerin tümünü ilk batıran oyunu kazanır.

+Kullandığım Classlar
-Gemiler: Bu class oyuncuların gemilerinin yerlerini ve sayısını tutar.
-Hücreler: Bu class tablodaki hücrelerin boş veya dolu olduğu bilgisini tutar.
-Oyuncular: Bu class oyuncuları host ve client olarak birbirine bağlamak için TCP/IP protokolünü kullanır.

+Sayfalar (Windows Forms)
-Start: Bu sayfa oyunun giriş sayfası ve oyuncuların bağlantı kurmasını sağlayan sayfadır.
-ShipPlacement: Bu sayfa oyuncuların gemilerini dikey veya yatay olarak yerleştirmesini sağlar.
-YerleştirmeHatası: Bu sayfa aynı hücreye birden fazla gemi yerleştirilmeye çalışıldığında ortaya çıkan hata sayfasıdır.
-Çalıştırma: Bu sayfa oyuncuların sırası ile birbirinin gemilerine ateş etmesini sağlar.
-AynıyereatışHatası: Bu sayfa daha önceden atış yapılan bir hücreye tekrar atış yapılmaya çalışıldığında ortaya çıkan hata sayfasıdır.
-Youwin: Oyunu kazanan oyuncunun karşısına çıkan sayfadır.
-YouLose: Oyunun kaybeden oyuncunun karşısına çıkan sayfadır.
