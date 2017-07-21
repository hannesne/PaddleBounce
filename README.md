---
title: Paddle Bounce
---

Overview
========

This is Paddle Bounce, a game of **skill**! Really, it’s just me learning to
code a HoloLens app.

The app is made using Unity, and the HoloToolkit.

You can see how far along progress currently is in [this
video](https://onedrive.live.com/?cid=BB52A773CDB6413F&id=BB52A773CDB6413F%211131623&parId=BB52A773CDB6413F%21120&o=OneUp).

The idea is to bounce a table tennis ball on a paddle. It has a scoreboard that
tracks your high score for the session.

Playing the game
================

When you open the game, you are presented with a paddle and a ball hanging in
the air above it. To start the game, you simply tap and hold on the paddle,
which starts the ball falling. Keep the paddle under the ball to make it bounce.
You get a point for every time the ball bounces on the paddle. Releasing the
paddle resets the position of the ball.

Things I’ve learnt from this project so far
================

1. Using the handdraggable script in the holotoolkit.

2. How to use the cursors in the holotoolkit.

3. How hard it is to edit 3d objects with free tools. This is way more work than I thought.

4. How to use the physics engine and collidors, and moving things around using both the physics engine and programmatically.

5. Particularly interesting is how to deal with fast moving objects. I had a problem with the ball falling through the paddle initially. Solution was to decrease the timesteps, and a few other small tweaks in the settings for the physics engine. Also enable dynamic continuous collision detection.

6.  Had a problem with the ball getting stuck in mid-air when you pulled the paddle away from under it. First solution was some code to detect it getting stuck and apply a bit of force to it. Replaced that with code to reawake the ball after every collision with the paddle. Way simpler.

7.  The combination of collidors and rigidbodies is particular about what can be used with what, when you use mesh collidors.

8.  Using the Audiosource to do spatial sound, so you can hear the ball bouncing off the paddle and on the ground. Initially started with the UAudioManager, but decided it’s overkill.

9.  Learnt about the tag-along and billboard scripts, and the 3d text prefab in the HoloToolkit. Ended up using the Sphere-based tagalong script. There’s a trick to that one if you want to keep your item along the edge of your UI. You need to attach the script to an invisible parent positioned in the middle of your viewpoint, and put your UI offset from that item. The script creates an invisible sphere in the center of your view, and tries to keep that parent in the sphere.

10. How to use materials from the asset store and shaders bundled in the holotoolkit.

11. The examples in the holotoolkit releases package is pretty useful to look at, while the documentation for the holotoolkit is absolutely atrocious.

12. Lerp.

My Todo list
============

1.  Write a set of short blog posts detailing the above.

2.  Add decals to the bat.

3.  See how the new version of Unity works. Currently using 6.4.

4.  Update the app assets (logos, icons, splash screens etc.)

5.  Refactor the game logic out of the various gameobject behaviours and into a gamemanager.

6.  Add animations to the scoreboard for when you hit the ball, and surpass the high score. Also make the scoreboard a bit nicer.

7.  Allow the user to position the paddle and ball when the game starts, and show some help text.

8.  Add a sad trombone when the ball hits the floor.

9.  Add voice commands for resetting the game.

10. Make it multi-player, so players can see each other, using the sharing  service.

11. Persist scores across sessions on the device.

12. Persist scores to the cloud for a leaderboard service.
