using System;

namespace Valve.VR
{
    public class SteamVR_Actions
    {

        private static SteamVR_Action_Pose p_default_Pose;

        private static SteamVR_Action_Skeleton p_default_SkeletonLeftHand;

        private static SteamVR_Action_Skeleton p_default_SkeletonRightHand;

        private static SteamVR_Action_Boolean p_default_PushToTalk;

        private static SteamVR_Action_Boolean p_default_SnapTurnLeft;

        private static SteamVR_Action_Boolean p_default_SnapTurnRight;

        private static SteamVR_Action_Vector2 p_default_Movement;

        private static SteamVR_Action_Boolean p_default_ToggleWatchMode;

        private static SteamVR_Action_Boolean p_default_Shoot;

        private static SteamVR_Action_Boolean p_default_Interact;

        private static SteamVR_Action_Boolean p_default_Jump;

        private static SteamVR_Action_Boolean p_default_Crouch;

        private static SteamVR_Action_Boolean p_default_WeaponSwitchLeft;

        private static SteamVR_Action_Boolean p_default_WeaponSwitchRight;

        private static SteamVR_Action_Boolean p_default_ToggleFlashlight;

        private static SteamVR_Action_Boolean p_default_Sprint;

        private static SteamVR_Action_Boolean p_default_Reload;

        private static SteamVR_Action_Boolean p_default_OpenMap;

        private static SteamVR_Action_Boolean p_default_OpenMenu;

        private static SteamVR_Action_Boolean p_default_Ping;

        private static SteamVR_Action_Vibration p_default_Haptic;

        public static SteamVR_Action_Pose default_Pose
        {
            get
            {
                return p_default_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }

        public static SteamVR_Action_Skeleton default_SkeletonLeftHand
        {
            get
            {
                return p_default_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }

        public static SteamVR_Action_Skeleton default_SkeletonRightHand
        {
            get
            {
                return p_default_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }

        public static SteamVR_Action_Boolean default_PushToTalk
        {
            get
            {
                return p_default_PushToTalk.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_SnapTurnLeft
        {
            get
            {
                return p_default_SnapTurnLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_SnapTurnRight
        {
            get
            {
                return p_default_SnapTurnRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Vector2 default_Movement
        {
            get
            {
                return p_default_Movement.GetCopy<SteamVR_Action_Vector2>();
            }
        }

        public static SteamVR_Action_Boolean default_ToggleWatchMode
        {
            get
            {
                return p_default_ToggleWatchMode.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Shoot
        {
            get
            {
                return p_default_Shoot.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Interact
        {
            get
            {
                return p_default_Interact.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Jump
        {
            get
            {
                return p_default_Jump.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Crouch
        {
            get
            {
                return p_default_Crouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WeaponSwitchLeft
        {
            get
            {
                return p_default_WeaponSwitchLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WeaponSwitchRight
        {
            get
            {
                return p_default_WeaponSwitchRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_ToggleFlashlight
        {
            get
            {
                return p_default_ToggleFlashlight.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Sprint
        {
            get
            {
                return p_default_Sprint.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Reload
        {
            get
            {
                return p_default_Reload.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_OpenMap
        {
            get
            {
                return p_default_OpenMap.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_OpenMenu
        {
            get
            {
                return p_default_OpenMenu.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Ping
        {
            get
            {
                return p_default_Ping.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Vibration default_Haptic
        {
            get
            {
                return p_default_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }

        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    default_Pose,
                    default_SkeletonLeftHand,
                    default_SkeletonRightHand,
                    default_PushToTalk,
                    default_SnapTurnLeft,
                    default_SnapTurnRight,
                    default_Movement,
                    default_ToggleWatchMode,
                    default_Shoot,
                    default_Interact,
                    default_Jump,
                    default_Crouch,
                    default_WeaponSwitchLeft,
                    default_WeaponSwitchRight,
                    default_ToggleFlashlight,
                    default_Sprint,
                    default_Reload,
                    default_OpenMap,
                    default_OpenMenu,
                    default_Ping,
                    default_Haptic};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    default_Pose,
                    default_SkeletonLeftHand,
                    default_SkeletonRightHand,
                    default_PushToTalk,
                    default_SnapTurnLeft,
                    default_SnapTurnRight,
                    default_Movement,
                    default_ToggleWatchMode,
                    default_Shoot,
                    default_Interact,
                    default_Jump,
                    default_Crouch,
                    default_WeaponSwitchLeft,
                    default_WeaponSwitchRight,
                    default_ToggleFlashlight,
                    default_Sprint,
                    default_Reload,
                    default_OpenMap,
                    default_OpenMenu,
                    default_Ping};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    default_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    default_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    default_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    default_PushToTalk,
                    default_SnapTurnLeft,
                    default_SnapTurnRight,
                    default_ToggleWatchMode,
                    default_Shoot,
                    default_Interact,
                    default_Jump,
                    default_Crouch,
                    default_WeaponSwitchLeft,
                    default_WeaponSwitchRight,
                    default_ToggleFlashlight,
                    default_Sprint,
                    default_Reload,
                    default_OpenMap,
                    default_OpenMenu,
                    default_Ping};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[0];
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[] {
                    default_Movement};
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[] {
                    default_SkeletonLeftHand,
                    default_SkeletonRightHand};
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    default_PushToTalk,
                    default_SnapTurnLeft,
                    default_SnapTurnRight,
                    default_Movement,
                    default_ToggleWatchMode,
                    default_Shoot,
                    default_Interact,
                    default_Jump,
                    default_Crouch,
                    default_WeaponSwitchLeft,
                    default_WeaponSwitchRight,
                    default_ToggleFlashlight,
                    default_Sprint,
                    default_Reload,
                    default_OpenMap,
                    default_OpenMenu,
                    default_Ping};
        }

        private static void PreInitActions()
        {
            p_default_Pose = SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/default/in/Pose");
            p_default_SkeletonLeftHand = SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonLeftHand");
            p_default_SkeletonRightHand = SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonRightHand");
            p_default_PushToTalk = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PushToTalk");
            p_default_SnapTurnLeft = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SnapTurnLeft");
            p_default_SnapTurnRight = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SnapTurnRight");
            p_default_Movement = SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/default/in/Movement");
            p_default_ToggleWatchMode = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/ToggleWatchMode");
            p_default_Shoot = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Shoot");
            p_default_Interact = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Interact");
            p_default_Jump = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Jump");
            p_default_Crouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Crouch");
            p_default_WeaponSwitchLeft = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WeaponSwitchLeft");
            p_default_WeaponSwitchRight = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WeaponSwitchRight");
            p_default_ToggleFlashlight = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/ToggleFlashlight");
            p_default_Sprint = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Sprint");
            p_default_Reload = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Reload");
            p_default_OpenMap = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/OpenMap");
            p_default_OpenMenu = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/OpenMenu");
            p_default_Ping = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Ping");
            p_default_Haptic = SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/default/out/Haptic");
        }
        public static SteamVR_Input_ActionSet_default _default
        {
            get
            {
                return p__default.GetCopy<SteamVR_Input_ActionSet_default>();
            }
        }

        private static void StartPreInitActionSets()
        {
            p__default = SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_default>("/actions/default");
            SteamVR_Input.actionSets = new SteamVR_ActionSet[]
            {
                _default
            };
        }

        public static void PreInitialize()
        {
            StartPreInitActionSets();
            SteamVR_Input.PreinitializeActionSetDictionaries();
            PreInitActions();
            InitializeActionArrays();
            SteamVR_Input.PreinitializeActionDictionaries();
            SteamVR_Input.PreinitializeFinishActionSets();
        }

        private static SteamVR_Input_ActionSet_default p__default;
    }
}
