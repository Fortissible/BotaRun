# :running_man: BotaRun
<p align="center">
  <img src="https://github.com/wildanfajri1alfarabi/BotaRun/blob/main/Assets/Title_Menu_Assets/Menu_Background_BotaRun_5.png" width="480" title="BotaRun">
</p>
<p align="center"><b>Botani Run</b></p>

## :open_book: Story
Welcome to IPB University, Ujang are the Computer Science major student in there. He's kinda sleepyhead and careless person, Because of that he really often late on all activities. However, He really care about the enviroment arround him, and he is a helpful person. Help Ujang for taking care of enviroment and help other people around him and help him so that he doesn't late for his activities.

## :page_with_curl: Rules
- You need to reach the finish spot before the time ran out.
- Finish spot wouldn't be unlocked unless you do all tasks on that floor.
- Tasks consist of interactions with game objects such as talking to NPC, planting, or feed a dog.
- There is a global timer which keeps counting down throughout your playthrough. If the timer reaches 0, you are out of the game.
- If you fall into a pit you die, instantly, no matter how many seconds are left on your timer.

## :triangular_flag_on_post: Goals
Clear all the quest and help Ujang to the finish spot in time. But be careful, dont fall in to the hole or get injured by other trap and obstacle.

## :superhero_man::mage::genie_man: Team

|Name                  |NIM        | Role                        |
|----------------------|-----------|-----------------------------|
|Wildan Fajri Alfarabi | G64190060 | Programmer & Artist         |
|Muhamad Rian Nayandra | G64190097 | Artist & Level Designer     |
|Jevon Sanoturia       | G64190056 | Programmer & Level Designer |

## :question: How to play

**Movement**    : Press A/D for move player into horizontal axis and W/S to climb up the stairs and crouch<br>
**Interact**    : Press E for interact with object to clear the level<br>
**Inventory**   : Press B to open backpack<br>
**Jump**        : Press Space for make the character jump<br>
**Skip Chat**   : Click left mouse to skip the dialogue<br>
**Main Menu**   : Press ESC to open main menu<br>

## :computer: Development Progress

Kami membuat game BotaRun dari scrap-scrap baik itu script maupun spritenya (ada yang kami buat sendiri menggunakan Aseprite dan Photoshop dan ada yang kami ambil dari UnityStore). Pembuatan script logic untuk game kami buat dengan bolak-balik buka tutorial youtube, dan yang paling kami sering lihat adalah channel milik Brackeys. Kami bagi-bagi tugas menjadi 3 tipe yaitu Programmer (Jevon, Wildan), Artist(Wildan,Rian), dan Level Designer(Jevon,Rian,Wildan). 

Dimana Programmer bekerja membuat logic dan script yang dibutuhkan agar game BotaRun berjalan dan Artist bekerja membuat sprite, animasi sprite, image object, dan juga BGM, lalu ada Level Designer yang membuat level BotaRun. Level kami ada 3 yang dibedakan dari teknik pencahayaan dan juga tingkat kesulitannya, dan ada juga level tutorial. Library maupun pipeline dan tools yang kami gunakan untuk membuatBotaRun seperti Cinemachine untuk camera-view yang mengikuti player, TextMeshPro untuk text didalam game, dan juga Universal Render Pipeline yang berfungsi untuk merender efek pencahayaan seperti Bloom, Ambient dan Diffuse.

Kami melihat banyak tutorial pada youtube dan kami lupa channel apa saja yang telah berjasa dalam pengembangan produk game BotaRun kami, tapi paling membantu adalah channel milik Brackeys yang membantu kami men-develope baik itu script (sisi logic) maupun sprite (sisi objek).

Di minggu pertama kami  mulai memilih tema dan genre dari game yang akan kami buat. Kami memilih tema IPB dengan genre game 2D platformer. Setelah menentukan. Setelah memilih tema dan genre, kemudian kami membuat beberapa script dasar yang akan menjadi base untuk sistem game yang akan kami buat. Kemudian kami juga commit project kami ke github.

Pada minggu kedua, kami memulai membuat script logic dari game seperti movement, detect collision, camera POV. Kami juga melanjutkan membuat aset original yang telah ditetapkan dan kami rasa butuh agar game kami terlihat lebih IPB.

Pada minggu selanjutnya, kami tinggal melanjutkan script-script yang kami butuhkan untuk menyelesaikan game kami, selain script, kami juga menyelesaikan sprite untuk objek-objek yang kami perlukan. 
Berikut adalah rangkuman development progress kelompok kami dalam membuat BotaRun dari minggu pertama sampai dengan minggu terakhir pengumpulan project Grafkom.


**Week 1** :
* Create project story and goals -> Wildan, Jevon, Rian
* First commit main project -> Wildan
* Create basic script -> Wildan
* Choosing template assets & create assets -> Rian

**Week 2** :
* Create movement script and logic -> Wildan, Jevon
* Add collision logic -> Wildan
* Customize camera POV -> Wildan, Jevon
* Continue creating assets -> Rian

**Week 3** :
* Assets menus & title -> Rian
* Assets character     -> Rian
* Interaction script   -> Jevon
* Dialogue system        -> Wildan

**Week 4** :
* Timer System -> Jevon
* Fail State (Time Limit) -> Jevon 
* Fail State (Trap, Fall) -> Wildan
* Finish State -> Rian
* Dialog interact radius -> Wildan
* Task System -> Wildan
* Main Menu, Char Assets continue -> Rian

**Week 5** :
* Use Item System -> Jevon
* Parallax Effect -> Wildan
* InGame BGM -> Rian
* Char Assets continue -> Rian

**Week 6-7** :
* Lvl 1 (Daytime) -> Jevon
* Lvl 2 (Nighttime) -> Rian
* Lvl 3 (Snow Weather) -> Wildan
* Pause function, animation fix -> Wildan

**Week 7++** :
* Ngelarin video, dokumentasi, paper, dll -> Jevon, Wildan, Rian

## :toolbox: Technology Stack
Tech-Stack used for this game :
* Adobe Photoshop, Aseprite
* Adobe Premiere, Audacity
* Unity 
* Visual Studio

## :wrench: Computer Graphic Technique 
|Teknik                 |Deskripsi                  | 
|-----------------------|---------------------------|
|Objek 2D               | Objek Char & 2D objek (Sprite), Background, Ground, dll.|
|Objek 3D               | -                         |
|Transformasi           | Translasi->Pergerakan Char, Rotasi->pergerakan salju di level 3 & Perputaran CrateBox ketika jatuh, Skalasi->Dialog menu|
|Pencahayaan            | Ambient, Diffuse          |
|Interaksi Mouse        | Button Click untuk interaksi dengan main menu, pause window, dan use item |
|Interaksi Keyboard     | Move character & Interact with NPC/Item & Opening Inventory | 
|Windowing              | Fullscreen & Windowed(1024x576)|
|Perspektif             | 2D (Side-view Orthograpic)|
|Fraktal                | Snowflake Koch Fractal in Main menu   |
|Tekstur                | -                         |

Illustration for each Technique in GoogleDocs Document : <br>
https://docs.google.com/document/d/1qRYqwPh6wsEHNw3HWO-t1dISdh-TA7n6AWwKRzbeGRU/edit?usp=sharing

## :white_square_button: Product Screenshots

<p align="center">
  <img src="https://github.com/wildanfajri1alfarabi/BotaRun/blob/main/Documentation/WhatsApp%20Image%202021-12-13%20at%2021.53.17.jpeg" width="480" title="BotaRun-SS1">
</p>

<p align="center">
  <img src="https://github.com/wildanfajri1alfarabi/BotaRun/blob/main/Documentation/WhatsApp%20Image%202021-12-13%20at%2021.53.17%20(2).jpeg" width="480" title="BotaRun-SS2">
</p>

<p align="center">
  <img src="https://github.com/wildanfajri1alfarabi/BotaRun/blob/main/Documentation/WhatsApp%20Image%202021-12-13%20at%2021.53.17%20(1).jpeg" width="480" title="BotaRun-SS3">
</p>

## :bow: Assets
Community asset that we used to make and create this project:
* [Blackspire Medieval Pixel Art Asset](https://assetstore.unity.com/packages/2d/environments/medieval-pixel-art-asset-free-130131 "Medieval Pixel Art")
* [Cainos Village Props](https://assetstore.unity.com/packages/2d/environments/pixel-art-platformer-village-props-166114 "Village Props")
* [Jesse Munguia Jungle Pack](https://jesse-m.itch.io/jungle-pack "Jungle Pack")
* [Ansimuz Sunny Land](https://assetstore.unity.com/packages/2d/characters/sunny-land-103349 "Sunnyland")

Dont forget to checkout the Asset Creator, they are awesome!

## Informasi Project
| Informasi             | URL                     | 
|-----------------------|-------------------------|
| Video Demo            | https://drive.google.com/drive/folders/1LaR_qY4Xkd5AXK4Pc6PLDM5mg3QIr_Sm?usp=sharing  |                         
| Figma                 | https://www.figma.com/file/86LoNW01SNvScHdzl1MGUJ/Gerafkom?node-id=0%3A1              |                         
| Assets Original       | https://drive.google.com/drive/folders/1my3RrCeL7rTxeqr3D9VeC2sk0e4c5k3i              | 
| GDocs Document        | https://docs.google.com/document/d/1qRYqwPh6wsEHNw3HWO-t1dISdh-TA7n6AWwKRzbeGRU/edit?usp=sharing |

