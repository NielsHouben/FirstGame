# **FirstGame**
first game, started with [youtube](https://www.youtube.com/watch?v=pwZpJzpE2lQ) from stefan pärson (Imphenzia), then moved on to add my own features

## **Introduction**
This is a 2.5D speed-running game. There are of course some classic spikes and pitfalls to avoid. But to really make this game interesting, I decided that I needed something more to make the game more interesting. I implemented various powerups, one that makes you run faster, another makes you jump higher, and the last gives you extra jumps! This allows for new ways of avoiding obstacles and finding faster routes to the end. Therefore, keeping the game interesting for many runs. In order to help out newer players out newer players to the game, I added some spawn points so that you can learn how to play the level without loosing all of your progress mid-level.

### **Problems**
I had some problems implementing the extra jumps functionality because I needed to make sure infinite jumps weren’t obtainable. My first implementation of this powerup just gave you another jump whenever you touched a surface so that regular jumping would still be allowed. However, that allowed a player to touch a wall mid-air, and then land, giving 2 jumps without taking a powerup. I solved this by adding a collision box at the players feet checking for actual ground touches. 

### **Future Thnking**
There has been some progress , but I would still consider the game under early development. I have yet to add multiple levels and a scoreboard leaderboard system. The graphics are currently temporary and will later be replaced with low-poly 3D models to increase the games visual appeal. I’m thinking that that will give the game a bit more character and lead me to thinking of a name for the game too. And once these things are at least improved upon, I plan to make the game playable through the web with WebGL, so that everyone can give it a run.
