# FlappyClone
Selamat datang pada FLAPPY CLONE! Unity 2019.2.5f1

Sebelum masuk kepada project ini, terdapat beberapa hal yang perlu diketahui
- SceneController, base class yang menjadi awal dari seluruh script yang terdapat pada scene.
  SceneController mengganti method built-in Unity seperti Start() dan Update().
  
- Component, Script yang diattach pada Scene(GameObject).
  Component berfungsi untuk menampilkan hasil logic kepada player dan mentrigger event-event tertentu.
  
- Logic, menjalankan berbagai proses game. Hasil dari proses tersebut akan dikirim pada components untuk ditunjukkan pada player.

Flow
  -SceneController dijalankan -> Initialize Logic -> Initialize Component.
