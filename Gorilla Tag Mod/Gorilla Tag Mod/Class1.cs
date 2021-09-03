using System;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR;
using Photon.Pun;
using System.IO;
using System.Net;
using Photon.Realtime;
using UnityEngine.Rendering;

namespace Fast_Monke
{
    [BepInPlugin("org.kokuchi.monkeytag.FastMonke", "Fast MONKE", "0.0.6.9")]
    public class MyPatcher : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("com.kokuchi.monkeytag.FastMonke");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class Class1
    {
            static void PostFix(GorillaLocomotion.Player __instance)
            {
                List<InputDevice> list = new List<InputDevice>();
                InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller, list);
                bool triggerDown = false;
            list[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerDown);
            if (PhotonNetwork.CurrentRoom.IsVisible) return;
            if (!PhotonNetwork.CurrentRoom.IsVisible || !PhotonNetwork.InRoom)

            if (triggerDown)
                {
                    __instance.jumpMultiplier = 10f;
                }
                else
                {
                    __instance.jumpMultiplier = 1.25f;
                }

                if (__instance.maxJumpSpeed < 999f)
                {
                    __instance.maxJumpSpeed = 999f;
                }

                }
            }
        }