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
        enum EEventAction
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

        enum EEventType
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

        enum ECameraTypes
        {
            CT_Predefined,
            CT_Speakers,
            CT_Actor,
            CT_Random,
        };

        enum ECameraPositions
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

        enum ECameraTransitions
        {
            TR_Jump,
            TR_Spline
        };

        enum ESpeechFonts
        {
            SF_Normal,
            SF_Computer
        };

        enum EAnimationModes
        {
            AM_Loop,
            AM_Once
        };

        enum EConditions
        {
            EC_Less,
            EC_LessEqual,
            EC_Equal,
            EC_GreaterEqual,
            EC_Greater
        };

        // Event Persona types
        enum EPersonaTypes
        {
            EP_Credits,
            EP_Health,
            EP_SkillPoints
        };

        public class ConEvent
        {
            struct eventType : EEventType { }
            String label;
            class nextEvent : ConEvent { }
            class conversation : Conversation { }

            public class ConEventAddCredits
            {
                int creditsToAdd;
            }
        }
    }
}
