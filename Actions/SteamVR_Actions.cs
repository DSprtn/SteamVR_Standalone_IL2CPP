using System;

namespace Valve.VR
{
    public class SteamVR_Actions
    {
        private static SteamVR_Action_Pose p_default_Pose;

        private static SteamVR_Action_Skeleton p_default_SkeletonLeftHand;

        private static SteamVR_Action_Skeleton p_default_SkeletonRightHand;

        private static SteamVR_Action_Boolean p_default_PushToTalk;

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

        private static SteamVR_Action_Vector2 p_default_SnapTurn;

        private static SteamVR_Action_Boolean p_default_AimOrShove;

        private static SteamVR_Action_Boolean p_default_OpenObjectives;

        private static SteamVR_Action_Boolean p_default_WeaponRadialMenu;

        private static SteamVR_Action_Boolean p_default_ToggleLaserPointer;

        private static SteamVR_Action_Boolean p_default_WatchRadialMenu;

        private static SteamVR_Action_Vibration p_default_Haptic;

        public static SteamVR_Action_Pose default_Pose
        {
            get
            {
                return SteamVR_Actions.p_default_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }

        public static SteamVR_Action_Skeleton default_SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }

        public static SteamVR_Action_Skeleton default_SkeletonRightHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }

        public static SteamVR_Action_Boolean default_PushToTalk
        {
            get
            {
                return SteamVR_Actions.p_default_PushToTalk.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Vector2 default_Movement
        {
            get
            {
                return SteamVR_Actions.p_default_Movement.GetCopy<SteamVR_Action_Vector2>();
            }
        }

        public static SteamVR_Action_Boolean default_ToggleWatchMode
        {
            get
            {
                return SteamVR_Actions.p_default_ToggleWatchMode.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Shoot
        {
            get
            {
                return SteamVR_Actions.p_default_Shoot.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Interact
        {
            get
            {
                return SteamVR_Actions.p_default_Interact.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Jump
        {
            get
            {
                return SteamVR_Actions.p_default_Jump.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Crouch
        {
            get
            {
                return SteamVR_Actions.p_default_Crouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WeaponSwitchLeft
        {
            get
            {
                return SteamVR_Actions.p_default_WeaponSwitchLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WeaponSwitchRight
        {
            get
            {
                return SteamVR_Actions.p_default_WeaponSwitchRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_ToggleFlashlight
        {
            get
            {
                return SteamVR_Actions.p_default_ToggleFlashlight.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Sprint
        {
            get
            {
                return SteamVR_Actions.p_default_Sprint.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Reload
        {
            get
            {
                return SteamVR_Actions.p_default_Reload.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_OpenMap
        {
            get
            {
                return SteamVR_Actions.p_default_OpenMap.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_OpenMenu
        {
            get
            {
                return SteamVR_Actions.p_default_OpenMenu.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_Ping
        {
            get
            {
                return SteamVR_Actions.p_default_Ping.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Vector2 default_SnapTurn
        {
            get
            {
                return SteamVR_Actions.p_default_SnapTurn.GetCopy<SteamVR_Action_Vector2>();
            }
        }

        public static SteamVR_Action_Boolean default_AimOrShove
        {
            get
            {
                return SteamVR_Actions.p_default_AimOrShove.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_OpenObjectives
        {
            get
            {
                return SteamVR_Actions.p_default_OpenObjectives.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WeaponRadialMenu
        {
            get
            {
                return SteamVR_Actions.p_default_WeaponRadialMenu.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_ToggleLaserPointer
        {
            get
            {
                return SteamVR_Actions.p_default_ToggleLaserPointer.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Boolean default_WatchRadialMenu
        {
            get
            {
                return SteamVR_Actions.p_default_WatchRadialMenu.GetCopy<SteamVR_Action_Boolean>();
            }
        }

        public static SteamVR_Action_Vibration default_Haptic
        {
            get
            {
                return SteamVR_Actions.p_default_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }

        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_PushToTalk,
                    SteamVR_Actions.default_Movement,
                    SteamVR_Actions.default_ToggleWatchMode,
                    SteamVR_Actions.default_Shoot,
                    SteamVR_Actions.default_Interact,
                    SteamVR_Actions.default_Jump,
                    SteamVR_Actions.default_Crouch,
                    SteamVR_Actions.default_WeaponSwitchLeft,
                    SteamVR_Actions.default_WeaponSwitchRight,
                    SteamVR_Actions.default_ToggleFlashlight,
                    SteamVR_Actions.default_Sprint,
                    SteamVR_Actions.default_Reload,
                    SteamVR_Actions.default_OpenMap,
                    SteamVR_Actions.default_OpenMenu,
                    SteamVR_Actions.default_Ping,
                    SteamVR_Actions.default_SnapTurn,
                    SteamVR_Actions.default_AimOrShove,
                    SteamVR_Actions.default_OpenObjectives,
                    SteamVR_Actions.default_WeaponRadialMenu,
                    SteamVR_Actions.default_ToggleLaserPointer,
                    SteamVR_Actions.default_WatchRadialMenu,
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_PushToTalk,
                    SteamVR_Actions.default_Movement,
                    SteamVR_Actions.default_ToggleWatchMode,
                    SteamVR_Actions.default_Shoot,
                    SteamVR_Actions.default_Interact,
                    SteamVR_Actions.default_Jump,
                    SteamVR_Actions.default_Crouch,
                    SteamVR_Actions.default_WeaponSwitchLeft,
                    SteamVR_Actions.default_WeaponSwitchRight,
                    SteamVR_Actions.default_ToggleFlashlight,
                    SteamVR_Actions.default_Sprint,
                    SteamVR_Actions.default_Reload,
                    SteamVR_Actions.default_OpenMap,
                    SteamVR_Actions.default_OpenMenu,
                    SteamVR_Actions.default_Ping,
                    SteamVR_Actions.default_SnapTurn,
                    SteamVR_Actions.default_AimOrShove,
                    SteamVR_Actions.default_OpenObjectives,
                    SteamVR_Actions.default_WeaponRadialMenu,
                    SteamVR_Actions.default_ToggleLaserPointer,
                    SteamVR_Actions.default_WatchRadialMenu};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.default_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.default_PushToTalk,
                    SteamVR_Actions.default_ToggleWatchMode,
                    SteamVR_Actions.default_Shoot,
                    SteamVR_Actions.default_Interact,
                    SteamVR_Actions.default_Jump,
                    SteamVR_Actions.default_Crouch,
                    SteamVR_Actions.default_WeaponSwitchLeft,
                    SteamVR_Actions.default_WeaponSwitchRight,
                    SteamVR_Actions.default_ToggleFlashlight,
                    SteamVR_Actions.default_Sprint,
                    SteamVR_Actions.default_Reload,
                    SteamVR_Actions.default_OpenMap,
                    SteamVR_Actions.default_OpenMenu,
                    SteamVR_Actions.default_Ping,
                    SteamVR_Actions.default_AimOrShove,
                    SteamVR_Actions.default_OpenObjectives,
                    SteamVR_Actions.default_WeaponRadialMenu,
                    SteamVR_Actions.default_ToggleLaserPointer,
                    SteamVR_Actions.default_WatchRadialMenu};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[0];
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[] {
                    SteamVR_Actions.default_Movement,
                    SteamVR_Actions.default_SnapTurn};
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[] {
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand};
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_PushToTalk,
                    SteamVR_Actions.default_Movement,
                    SteamVR_Actions.default_ToggleWatchMode,
                    SteamVR_Actions.default_Shoot,
                    SteamVR_Actions.default_Interact,
                    SteamVR_Actions.default_Jump,
                    SteamVR_Actions.default_Crouch,
                    SteamVR_Actions.default_WeaponSwitchLeft,
                    SteamVR_Actions.default_WeaponSwitchRight,
                    SteamVR_Actions.default_ToggleFlashlight,
                    SteamVR_Actions.default_Sprint,
                    SteamVR_Actions.default_Reload,
                    SteamVR_Actions.default_OpenMap,
                    SteamVR_Actions.default_OpenMenu,
                    SteamVR_Actions.default_Ping,
                    SteamVR_Actions.default_SnapTurn,
                    SteamVR_Actions.default_AimOrShove,
                    SteamVR_Actions.default_OpenObjectives,
                    SteamVR_Actions.default_WeaponRadialMenu,
                    SteamVR_Actions.default_ToggleLaserPointer,
                    SteamVR_Actions.default_WatchRadialMenu};
        }

        private static void PreInitActions()
        {
            SteamVR_Actions.p_default_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/default/in/Pose")));
            SteamVR_Actions.p_default_SkeletonLeftHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonLeftHand")));
            SteamVR_Actions.p_default_SkeletonRightHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonRightHand")));
            SteamVR_Actions.p_default_PushToTalk = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PushToTalk")));
            SteamVR_Actions.p_default_Movement = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/default/in/Movement")));
            SteamVR_Actions.p_default_ToggleWatchMode = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/ToggleWatchMode")));
            SteamVR_Actions.p_default_Shoot = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Shoot")));
            SteamVR_Actions.p_default_Interact = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Interact")));
            SteamVR_Actions.p_default_Jump = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Jump")));
            SteamVR_Actions.p_default_Crouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Crouch")));
            SteamVR_Actions.p_default_WeaponSwitchLeft = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WeaponSwitchLeft")));
            SteamVR_Actions.p_default_WeaponSwitchRight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WeaponSwitchRight")));
            SteamVR_Actions.p_default_ToggleFlashlight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/ToggleFlashlight")));
            SteamVR_Actions.p_default_Sprint = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Sprint")));
            SteamVR_Actions.p_default_Reload = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Reload")));
            SteamVR_Actions.p_default_OpenMap = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/OpenMap")));
            SteamVR_Actions.p_default_OpenMenu = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/OpenMenu")));
            SteamVR_Actions.p_default_Ping = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Ping")));
            SteamVR_Actions.p_default_SnapTurn = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/default/in/SnapTurn")));
            SteamVR_Actions.p_default_AimOrShove = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/AimOrShove")));
            SteamVR_Actions.p_default_OpenObjectives = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/OpenObjectives")));
            SteamVR_Actions.p_default_WeaponRadialMenu = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WeaponRadialMenu")));
            SteamVR_Actions.p_default_ToggleLaserPointer = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/ToggleLaserPointer")));
            SteamVR_Actions.p_default_WatchRadialMenu = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/WatchRadialMenu")));
            SteamVR_Actions.p_default_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/default/out/Haptic")));
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