<h1> PVB project Linux </h1>

### Produced  Game Onderdelen
Byron:
  * [Mockup multiplayer](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/FakePlayer/FakePlayerMove.cs)
  * [Player movement](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Player/PlayerMovement.cs)
  * [Wave system](https://github.com/DaanKikkert/PVB/tree/develop/PVB%20Linx%20Groep%206/Assets/Code/Scripts/WaveSpawner)
  * [Class system](https://github.com/DaanKikkert/PVB/tree/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Class%20System)
  * [Respawning of players](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/PlayerRespawnManager/PlayerRespawn.cs)
  * [Game Reset](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/ResetGame/ResetGame.cs)
  * [Universal fadeout effect](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/FadeToBlack/FadeEffect.cs)
  * [Reworked Emote system](https://github.com/DaanKikkert/PVB/tree/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Emote)
  * [Reworked Ping system](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Ping/PingSystem.cs)

Daan:   
  * [Weapon system](https://github.com/DaanKikkert/PVB/tree/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Weapons)
  * [Player Attack Script](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Weapons/PlayerAttack.cs)
  * [Reworked Enemies Scripts](https://github.com/DaanKikkert/PVB/tree/develop/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Enemy)
  * [MockUp Player Attack](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/FakePlayer/FakePlayerAttack.cs)
  * [Universal Health Script (with Guido)](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/UniversalHealth.cs)
  * [Wave UI Script](https://github.com/DaanKikkert/PVB/blob/5cbc20f5223e2786f4299e424f36f4eb3656dc7c/PVB%20Linx%20Groep%206/Assets/Code/Scripts/WaveUI.cs?raw=true)

Dirk:
  * [Old enemies](https://github.com/DaanKikkert/PVB/blob/final-build/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Enemy/Enemy.cs)
  * [Placeable Turrets](https://github.com/DaanKikkert/PVB/blob/feature/build-structures/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Build%20Structure/BuildStructure.cs)
  * [Shop](https://github.com/DaanKikkert/PVB/tree/final-build/PVB%20Linx%20Groep%206/Assets/Code/Scripts/UI/Shop)
  * [Experience with Guido](https://github.com/DaanKikkert/PVB/blob/feature/experience-system/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Player/Experience.cs)
  * [Player Animations Moving](https://github.com/DaanKikkert/PVB/blob/develop/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Player/PlayerMovement.cs)
  * [Player Animations Attack](https://github.com/DaanKikkert/PVB/blob/develop/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Weapons/PlayerAttack.cs)
  * [Healthbar](https://github.com/DaanKikkert/PVB/blob/final-build/PVB%20Linx%20Groep%206/Assets/Code/Scripts/UI/Health/ShowHealth.cs)

Guido:
  * [Universal health with Daan](https://github.com/DaanKikkert/PVB/blob/final-build/PVB%20Linx%20Groep%206/Assets/Code/Scripts/UniversalHealth.cs)
  * First build of ping system
  * First build of Emote system
  * [Experience with Dirk](https://github.com/DaanKikkert/PVB/blob/feature/experience-system/PVB%20Linx%20Groep%206/Assets/Code/Scripts/Player/Experience.cs)
<details>
  <summary>
    <b>Press to see the concept </b>
  </summary>    

 <break>
  The concept of the game is a survival game where a horde of enemies comes at you and tries to destroy your castle. There is at least one player but it can be played with multiple players who must work together to protect the castle from the endless waves of enemies. They come in increasingly larger groups and constantly grow stronger with each wave. The players will do their best to hold out for as long as possible by killing the enemies and protecting the castle. Each player has a class that specializes in a particular function, so careful consideration must be given to the composition of the team as each class has strengths and weaknesses.

There is no way to communicate with each other via text, but there are emotes that make it difficult to understand each other, encouraging players to stay together longer as they try to understand what the other is trying to convey.

Players can choose between different weapons with various ammunition types. Experiment with different combinations that suit your playstyle and eliminate all the enemies. The enemies can also use weapons themselves, so be vigilant and watch out because the zombie might have the same combination you do.

Protect the castle with everything you have because if the castle falls, the game is over.
</details>


[Git Wiki](https://github.com/DaanKikkert/PVB/wiki)
