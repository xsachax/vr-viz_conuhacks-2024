# ConUHacks VIII project 🔥

Virtual reality app highlighting trends in Montreal's Open Data.

* Running in Unity version 2022.3.17

Contributors:
- Sacha Arseneault
- Rui Du
- Ryan Awad
- Xavier D'mello

# Requirements 📄
- A computer running Windows (sorry Mac users) which meets the Quest Link standards, see https://www.meta.com/help/quest/articles/headsets-and-accessories/oculus-link/requirements-quest-link/
- A Meta Quest series VR headset
- A USB 2.0 cable (USB 3.0 is recommended, but 2.0 will work fine)
- A compatible unity version, ideally 2022.3.17
- A working google maps API key, see https://youtu.be/lLw5hCqSv5Y?t=164 (warning: running this project might cost you a few cents)

# Setup 🛠️
1. Install Unity and downlad editor version 2022.3.17 from Unity Hub (https://unity.com/download)
2. Install Oculus Software (https://www.meta.com/help/quest/articles/headsets-and-accessories/oculus-rift-s/install-app-for-link/)
3. Install Meta Quest Developer Hub and follow basic instructions (https://developer.oculus.com/documentation/unity/ts-odh/)
4. Make a meta accoount, and login to the headset, MQDH and Oculus Software.
5. Plug your headset into your computer using the USB cable, select "Allow" on the headset
6. Pair your headset with MQDH and enable developer mode (on both). You might need to create/join an organization, just make a dummy one.
7. In Oculus Software, go to Settings, general and turn ON "Unknown Sources"
8. Turn On Quest Link from the headset settings and look for your computer. Once the headset it should appear in "Devices" on Oculus Software.
9. Once the headset is successfully connected with Quest Link, your setup is ready.

# How to try it 🎮
1. Clone the repo
2. On Unity Hub, select Add project and find your local copy of the repo
3. Open the project (this might take a bit the first time)
4. In the hierarchy (left side), find the Cesium3DTileset GameObject under CesiumGeoreference
5. In the URL field, past in your api key at the end of the url like this https://tile.googleapis.com/v1/3dtiles/root.json?key=<YOUR_API_KEY>
6. Save the project with CTRL-S
7. Make sure Quest Link is still enabled. If not try restarting the Oculus software, and/or unpluging and repluging your headset. (Sometimes it bugs and requires a restart of the headset/computer)
9. Click the Play button at the top of the screen and put on the headset.
10. Voila! You're flying above Montreal. The current datasets are Collisions (purple) vs High-traffic intersections (yellow)
11. You can move around by pushing the left joystick forward (will move towards where you're facing), and rotate with the right joystick.

If you have any questions, I'd be more than happy to answer them. Shoot me a message at sacha.arseneault@gmail.com.


  
