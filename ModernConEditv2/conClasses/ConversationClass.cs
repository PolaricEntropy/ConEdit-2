using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernConEditv2
{
    class ConversationClass
    {
    }

    public class ConObject
    {
        public enum EEventAction
        {
            EA_NextEvent,
            EA_JumpToLabel,
            EA_JumpToConversation,
            EA_WaitForInput,
            EA_WaitForSpeech,
            EA_PlayAnim,
            EA_ConTurnActors,
            EA_End
        };

        public enum EEventType
        {
            ET_Speech,
            ET_Choice,
            ET_SetFlag,
            ET_CheckFlag,
            ET_CheckObject,
            ET_TransferObject,
            ET_MoveCamera,
            ET_Animation,
            ET_Trade,
            ET_Jump,
            ET_Random,
            ET_Trigger,
            ET_AddGoal,
            ET_AddNote,
            ET_AddSkillPoints,
            ET_AddCredits,
            ET_CheckPersona,
            ET_Comment,
            ET_End
        };

        public enum ECameraTypes
        {
            CT_Predefined,
            CT_Speakers,
            CT_Actor,
            CT_Random,
        };

        public enum ECameraPositions
        {
            CP_SideTight,
            CP_SideMid,
            CP_SideAbove,
            CP_SideAbove45,
            CP_ShoulderLeft,
            CP_ShoulderRight,
            CP_HeadShotTight,
            CP_HeadShotMid,
            CP_HeadShotLeft,
            CP_HeadShotRight,
            CP_HeadShotSlightRight,
            CP_HeadShotSlightLeft,
            CP_StraightAboveLookingDown,
            CP_StraightBelowLookingUp,
            CP_BelowLookingUp
        };

        public enum ECameraTransitions
        {
            TR_Jump,
            TR_Spline
        };

        public enum ESpeechFonts
        {
            SF_Normal,
            SF_Computer
        };

        public enum EAnimationModes
        {
            AM_Loop,
            AM_Once
        };

        public enum EConditions
        {
            EC_Less,
            EC_LessEqual,
            EC_Equal,
            EC_GreaterEqual,
            EC_Greater
        };

        // Event Persona types
        public enum EPersonaTypes
        {
            EP_Credits,
            EP_Health,
            EP_SkillPoints
        };        
    }

    public class ConEvent : ConObject
    {
        public struct eventType : EEventType { }
        public String label;
        public class nextEvent : ConEvent { }
        public class conversation : Conversation { }       
    }

    public class ConEventAddCredits : ConEvent
    {
        public int creditsToAdd;
    }

    public class Conversation : ConObject
    {
        public name conName;				// Conversation Name
        public String Description;			// Description
        public String CreatedBy;				// Who created event
        public String conOwnerName;			// Name of Actor owner
        public bool bDataLinkCon;			// True if this is a DataLink conversation

        public bool bDisplayOnce;			// Flag to display conversation only once
        public bool bFirstPerson;			// Remain in First-Person mode
        public bool bNonInteractive;		// True if non-interactive conversation
        public bool bRandomCamera;			// True if random camera placement
        public bool bCanBeInterrupted;		// True if this conversation can be interrupted by another
        public bool bCannotBeInterrupted;	// True if this conversation CANNOT be interrupted by another
        public bool bGenerateAudioNames;	// True if we're to auto-generate filenames for the audio

        public bool bInvokeBump;			// Invoke by Bumping
        public bool bInvokeFrob;			// Invoke by Frobbing
        public bool bInvokeSight;			// Invoke by Sight
        public bool bInvokeRadius;			// Invoke by Radius
        public int radiusDistance;		// Distance from PC needed to invoke conversation, 0 = Frob

        public ConEvent eventList;				// First Event
        public ConFlagRef flagRefList;			// Flag List

        public int conversationID;		// Internal Conversation ID

        // Unique identifier of audio package.  This is used to generate
        // audio names so we can demand load audio from a package
        public String audioPackageName;

        public float lastPlayedTime;		// Time when conversation last played (ended).
        public int ownerRefCount;			// Number of owners this conversation has
    }

    public class ConversationList : ConObject
    {
        public ConItem      conversations;
        public string       missionDescription;
        public int          missionNumber;
    }

    public class ConversationMissionList : ConObject
    {
        public ConItem missions;
    }

    public class ConSpeech : ConObject
    {
        public string speech;
        public int soundID;
    }

    public class ConListItem : ConObject
    {
        public Conversation con;
        public ConListItem next;
    }

    public class ConLight : Light
    {
        public int actorDistance;
    }

    public class ConItem : ConObject
    {
        public ConObject conObject;
        public ConItem next;
    }

    public class ConHistoryEvent : ConObject
    {
        public string conSpeaker;
        public string speech;
        public int soundID;
        public ConHistoryEvent next;
    }

    public class ConHistory : ConObject
    {
        public string conOwnerName;
        public string strLocation;
        public string strDescription;
        public bool bInfoLink;
        public ConHistoryEvent firstEvent;
        public ConHistoryEvent lastEvent;
        public ConHistory next;
    }

    public class ConFlagRef : ConObject
    {
        public name flagName;
        public bool value;
        public int expiration;
        public ConFlagRef nextFlagRef;
    }

    public class ConAudioList : ConObject
    {
        public const DynamicArray conAudioList;
        public int audioCount;
    }

    public class ConCamera : ConObject
    {
        public Actor            cameraActor;			// Actor who owns this event
        public ECameraPositions cameraPosition;		// Predefined camera position
        public ECameraTypes     cameraType;			// Camera Type
        public ECameraTypes     cameraMode;
        public ConLight         conLightSpeaker;		// Used to light actor's faces
        public ConLight         conLightSpeakingTo;	// Used to light actor's faces

        public vector cameraOffset;
        public rotator rotation;
        public float   cosAngle;
        public int     firstActorRotation;
        public int     setActorCount;
        public bool    bCameraLocationSaved;

        // Camera Fallback Positions (for when camera view obstructed)
        public ECameraPositions cameraFallbackPositions[9];
        public ECameraPositions cameraHeightPositions[9];

        public int   currentFallback;
        public bool  bUsingFallback;

        // Used for CT_Speakers mode
        public float heightModifier;
        public float centerModifier;
        public float distanceMultiplier;		
        public float heightFallbackTrigger;

        // Actors associated with camera placement
        public Actor firstActor;
        public Actor secondActor;

        // These publiciable are used to prevent camera angle changes when the 
        // actors change.
        public Actor lastFirstActor;
        public Actor lastSecondActor;
        public bool  ignoreSetActors;

        // Used for Camera debugging
        public bool  bDebug;
        public vector LastLocation;
        public rotator LastRotation;
        public bool  binteractiveCamera;
    }

    public class ConCameraWindow : TextWindow
    {
        public ConCamera camera; 
    }

    public class ConChoice : ConObject
    {
        public string choiceText;
        public string choiceLabel;
        public bool bDisplayasSpeech;
        public int soundID;
        public class skillNeeded;
        public int skillLevelNeeded;
        public ConFlagRef flagRef;
        public ConChoice nextChoice;
    }

    public class ConEventChoice : ConEvent
    {
        public bool bClearScreen;
        public ConChoice ChoiceList;
    }

    public class ConEventCheckPersona : ConEvent
    {
        public EPersonaTypes personaType;
        public EConditions condition;
        public int value;
        public string jumpLabel;
    }

    public class ConEventCheckObject : ConEvent
    {
        public string objectName;
        public class<inventory> checkObject;
        public string failLabel;
    }

    public class ConEventCheckFlag : ConEvent
    {
        public ConFlagRef flagRef;
        public string setLabel;
    }

    public class ConEventAnimation : ConEvent
    {
        public Actor eventOwner;
        public string eventOwnerName;
        public name sequence;
        public bool bFinishAnim;
        public bool bLoopAnim;
    }

    public class ConEventAddSkillPoints : ConEvent
    {
        public int pointsToAdd;
        public string awardMessage;
    }

    public class ConEventAddNote : ConEvent
    {
        public string noteText;
        public bool bNoteAdded;
    }

    public class ConEventTrigger : ConEvent
    {
        public name triggertag;
    }

    public class ConEventTransferObject : ConEvent
    {
        public string objectName;					// Name of object to transfer
        public class<Inventory> giveObject;		    // Object to transfer
        public int    transferCount;				// Number of objects to transfer
        public Actor  fromActor;					// Actor transfering from
        public string fromName;					    // string name
        public Actor toActor;						// Actor transfering to
        public string toName;						// string name
        public string failLabel;					// On fail jump to this label
    }

    public class ConEventTrade : ConEvent
    {
        public Actor eventOwner;
        public string eventOwnerName;
    }

    public class ConEventSpeech : ConEvent
    {
        public Actor speaker;						// Actor speaking
        public string speakerName;					// Text name
        public Actor speakingTo;					// Actor being spoken to
        public string speakingToName;				// Text name
        public ConSpeech conSpeech;				    // Speech
        public bool bContinued;					    // True if continued from last speech
        public bool bBold;							// True if text is bold
        public ESpeechFonts speechFont;			    // Speech Font
    }

    public class ConEventSetFlag : ConEvent
    {
        public ConFlagRef flagRef;
    }

    public class ConEventRandomLabel : ConEvent
    {
        private DynamicArray labels;
        public bool bCycleEvents;
        public bool bCycleOnce;
        public bool bCycleRandom;

        public int cycleIndex;
        public bool bLabelsCycled;
    }

    public class ConEventMoveCamera : ConEvent
    {
        public ECameraTypes cameraType;
        public ECameraPositions cameraPosition;
        public ECameraTransitions camera Transition;

        public Vector cameraOffset;
        public Rotator rotation;
        public float heightModifier;
        public float centerModifier;
        public float distanceMultiplier;

        public Actor cameraActor;
        public string cameraActorName;
    }

    public class ConEventJump : ConEvent
    {
        public string jumpLabel;
        public Conversation jumpCon;
        public int conID;
    }

    public class ConEventEnd : ConEvent
    {
    }

    public class ConEventComment : ConEvent
    {
        public string commentText;
    }

    public class ConEventAddGoal : ConEvent
    {
        public name goalName;
        public bool bGoalCompleted;
        public string goalText;
        public bool bPrimaryGoal;
    }
}
