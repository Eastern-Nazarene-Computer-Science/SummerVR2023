1. Ensure you have Unity 2021.3.25f1 or latest LTS, Oculus software, and Github setup and make sure they are up-to-date
2. Import or create a new project using version 2021.3.25f1
3. Once the project is open, go to Window > Package Manager
4. Install XR Plugin Management, XR Interaction Toolkit, OpenXR Plugin, and Oculus XR Plugin
5. Next, go to Edit > Project Settings and find XR Plug-in Management
6. Check Oculus and let it install
7. Uncheck Oculus and check OpenXR
8. Click the Android icon and repeat steps 6 and 7
9. Click OpenXR in the left panel(you may have to expand XR Plug-in Management)
10. Click the Android icon
11. Click the + button under Interaction Profiles and select Oculus Touch Controller Profile
12. In your hierarchy, right click and go to XR > XR Origin (VR)
13. Right click again and go to XR > XR Interaction Manager
14. Check the boxes for Meta Quest Support and Runtime Debugger
14. Delete the Main Camera object in your hierarchy
15. Make sure your headset is connected in the Oculus app, then test your scene