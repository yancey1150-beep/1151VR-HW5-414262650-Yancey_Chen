1. Scene & Terrain Construction

⚬ Added a Terrain object and adjusted its dimensions under Terrain Settings > Mesh Resolution.
⚬ Sculpted rolling mountains in the background using Raise or Lower Terrain.
⚬ Applied a grass base color/texture via Paint Texture and Terrain Layers, then populated the scene with trees and grass (LPW_Grass_A1_40cm_01).

2. 3D Model Importing & Material Fixes

⚬ Imported three main 3D assets into the scene: the Trainer (HumanDummy_F Purple), the Monster/Pokémon (Monster37_01), and the Pokéball (SplitMetalBall).
⚬ Resolved a texture import error on Monster37_01.png (File could not be read) by re-exporting and reimporting the PNG.
⚬ Fixed the purple/pink shader mismatch on SplitMetalBall by converting its Built-in materials to URP (Edit > Rendering > Materials > Convert Selected Built-in Materials to URP).

3. Camera, Animation & Throwing Mechanics

⚬ Third-Person Camera (CameraFollow.cs): Attached a LateUpdate tracking script to Main Camera to smoothly follow behind the trainer.
⚬ Arm Throwing Animation (ArmThrowSwing.cs): Targeted the trainer's right upper arm bone (B-upper_arm.R nested under Rig > B-root > B-hips > B-spine > B-chest). Programmed a 3-phase rotation (wind up back → snap forward → return to initial rotation) using localRotation to prevent bone spinning.
⚬ Pokéball Physics & Capture (PokeballThrow.cs):
  ⚬ Synced the ball's Throw() method to fire the moment the arm transitions from wind-up to forward swing.
  ⚬ Used Rigidbody (linearVelocity and gravity) to arc the ball from left to right.
  ⚬ Set up OnTriggerEnter with a Pokemon tag to hide the monster and trigger a Particle System capture effect on impact.
⚬ Input Handling: Set Unity's Active Input Handling to Both so throwing works with both the Space key and screen taps/mouse clicks.

4. iOS Mobile Build & Deployment

⚬ Switched the build platform to iOS and locked the orientation to Landscape.
⚬ Configured a valid reverse-domain Bundle Identifier in Xcode's Signing & Capabilities to replace the invalid "-" identifier and generate a provisioning profile.
⚬ Switched the Xcode run target from iOS-simulator to a physical iPhone ([iOS, arm64]) to resolve the architecture mismatch and deploy the app.

Controls / Operations

⚬ Desktop (Unity Editor): Press Space or Left-Click to wind up the trainer's arm and throw the Pokéball.
⚬ Mobile (iOS): Tap anywhere on the screen to throw the Pokéball and capture the Pokémon.

If you need a Traditional Chinese version of this formatted specifically as a ready-to-paste README.md for your GitHub submission, let me know.
