using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using System.Reflection;
using System.Text;
using static TheOtherRoles.TheOtherRoles;

namespace TheOtherRoles {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] presets = new string[]{"预设 1", "预设 2", "预设 3", "预设 4", "预设 5"};

        public static CustomOption presetSelection;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;

        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption vampireSpawnRate;
        public static CustomOption vampireKillDelay;
        public static CustomOption vampireCooldown;
        public static CustomOption vampireCanKillNearGarlics;

        public static CustomOption eraserSpawnRate;
        public static CustomOption eraserCooldown;
        public static CustomOption eraserCanEraseAnyone;

        public static CustomOption miniSpawnRate;
        public static CustomOption miniGrowingUpDuration;

        public static CustomOption loversSpawnRate;
        public static CustomOption loversImpLoverRate;
        public static CustomOption loversBothDie;
        public static CustomOption loversCanHaveAnotherRole;
        public static CustomOption loversEnableChat;

        public static CustomOption guesserSpawnRate;
        public static CustomOption guesserIsImpGuesserRate;
        public static CustomOption guesserNumberOfShots;
        public static CustomOption guesserHasMultipleShotsPerMeeting;
        public static CustomOption guesserShowInfoInGhostChat;
        public static CustomOption guesserKillsThroughShield;
        public static CustomOption guesserEvilCanKillSpy;
        public static CustomOption guesserSpawnBothRate;
        public static CustomOption guesserCantGuessSnitchIfTaksDone;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;
        public static CustomOption jesterHasImpostorVision;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalCreateSidekickCooldown;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanCreateSidekick;
        public static CustomOption sidekickPromotesToJackal;
        public static CustomOption sidekickCanKill;
        public static CustomOption sidekickCanUseVents;
        public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
        public static CustomOption jackalCanCreateSidekickFromImpostor;
        public static CustomOption jackalAndSidekickHaveImpostorVision;

        public static CustomOption bountyHunterSpawnRate;
        public static CustomOption bountyHunterBountyDuration;
        public static CustomOption bountyHunterReducedCooldown;
        public static CustomOption bountyHunterPunishmentTime;
        public static CustomOption bountyHunterShowArrow;
        public static CustomOption bountyHunterArrowUpdateIntervall;

        public static CustomOption witchSpawnRate;
        public static CustomOption witchCooldown;
        public static CustomOption witchAdditionalCooldown;
        public static CustomOption witchCanSpellAnyone;
        public static CustomOption witchSpellCastingDuration;
        public static CustomOption witchTriggerBothCooldowns;
        public static CustomOption witchVoteSavesTargets;

        public static CustomOption shifterSpawnRate;
        public static CustomOption shifterShiftsModifiers;

        public static CustomOption mayorSpawnRate;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffCanKillNeutrals;
        public static CustomOption deputySpawnRate;

        public static CustomOption deputyNumberOfHandcuffs;
        public static CustomOption deputyHandcuffCooldown;
        public static CustomOption deputyGetsPromoted;
        public static CustomOption deputyKeepsHandcuffs;
        public static CustomOption deputyHandcuffDuration;
        public static CustomOption deputyKnowsSheriff;

        public static CustomOption lighterSpawnRate;
        public static CustomOption lighterModeLightsOnVision;
        public static CustomOption lighterModeLightsOffVision;
        public static CustomOption lighterCooldown;
        public static CustomOption lighterDuration;

        public static CustomOption detectiveSpawnRate;
        public static CustomOption detectiveAnonymousFootprints;
        public static CustomOption detectiveFootprintIntervall;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveReportNameDuration;
        public static CustomOption detectiveReportColorDuration;

        public static CustomOption timeMasterSpawnRate;
        public static CustomOption timeMasterCooldown;
        public static CustomOption timeMasterRewindTime;
        public static CustomOption timeMasterShieldDuration;

        public static CustomOption medicSpawnRate;
        public static CustomOption medicShowShielded;
        public static CustomOption medicShowAttemptToShielded;
        public static CustomOption medicSetShieldAfterMeeting;
        public static CustomOption medicShowAttemptToMedic;

        public static CustomOption swapperSpawnRate;
        public static CustomOption swapperCanCallEmergency;
        public static CustomOption swapperCanOnlySwapOthers;

        public static CustomOption seerSpawnRate;
        public static CustomOption seerMode;
        public static CustomOption seerSoulDuration;
        public static CustomOption seerLimitSoulDuration;

        public static CustomOption hackerSpawnRate;
        public static CustomOption hackerCooldown;
        public static CustomOption hackerHackeringDuration;
        public static CustomOption hackerOnlyColorType;
        public static CustomOption hackerToolsNumber;
        public static CustomOption hackerRechargeTasksNumber;
        public static CustomOption hackerNoMove;

        public static CustomOption trackerSpawnRate;
        public static CustomOption trackerUpdateIntervall;
        public static CustomOption trackerResetTargetAfterMeeting;
        public static CustomOption trackerCanTrackCorpses;
        public static CustomOption trackerCorpsesTrackingCooldown;
        public static CustomOption trackerCorpsesTrackingDuration;

        public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
        public static CustomOption snitchIncludeTeamJackal;
        public static CustomOption snitchTeamJackalUseDifferentArrowColor;

        public static CustomOption spySpawnRate;
        public static CustomOption spyCanDieToSheriff;
        public static CustomOption spyImpostorsCanKillAnyone;
        public static CustomOption spyCanEnterVents;
        public static CustomOption spyHasImpostorVision;

        public static CustomOption tricksterSpawnRate;
        public static CustomOption tricksterPlaceBoxCooldown;
        public static CustomOption tricksterLightsOutCooldown;
        public static CustomOption tricksterLightsOutDuration;

        public static CustomOption cleanerSpawnRate;
        public static CustomOption cleanerCooldown;
        
        public static CustomOption warlockSpawnRate;
        public static CustomOption warlockCooldown;
        public static CustomOption warlockRootTime;

        public static CustomOption securityGuardSpawnRate;
        public static CustomOption securityGuardCooldown;
        public static CustomOption securityGuardTotalScrews;
        public static CustomOption securityGuardCamPrice;
        public static CustomOption securityGuardVentPrice;
        public static CustomOption securityGuardCamDuration;
        public static CustomOption securityGuardCamMaxCharges;
        public static CustomOption securityGuardCamRechargeTasksNumber;
        public static CustomOption securityGuardNoMove;

        public static CustomOption baitSpawnRate;
        public static CustomOption baitHighlightAllVents;
        public static CustomOption baitReportDelay;
        public static CustomOption baitShowKillFlash;

        public static CustomOption vultureSpawnRate;
        public static CustomOption vultureCooldown;
        public static CustomOption vultureNumberToWin;
        public static CustomOption vultureCanUseVents;
        public static CustomOption vultureShowArrows;

        public static CustomOption mediumSpawnRate;
        public static CustomOption mediumCooldown;
        public static CustomOption mediumDuration;
        public static CustomOption mediumOneTimeUse;

        public static CustomOption lawyerSpawnRate;
        public static CustomOption lawyerTargetKnows;
        public static CustomOption lawyerWinsAfterMeetings;
        public static CustomOption lawyerNeededMeetings;
        public static CustomOption lawyerVision;
        public static CustomOption lawyerKnowsRole;
        public static CustomOption pursuerCooldown;
        public static CustomOption pursuerBlanksNumber;

        public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption allowParallelMedBayScans;

        public static CustomOption dynamicMap;
        public static CustomOption dynamicMapEnableSkeld;
        public static CustomOption dynamicMapEnableMira;
        public static CustomOption dynamicMapEnablePolus;
        public static CustomOption dynamicMapEnableDleks;
        public static CustomOption dynamicMapEnableAirShip;


        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load() {
            
            // Role Options
            presetSelection = CustomOption.Create(0, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "预设"), presets, null, true);
            activateRoles = CustomOption.Create(1, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "关闭原版职业并开启MOD职业"), true, null, true);

            // Using new id's for the options to not break compatibilty with older versions
            crewmateRolesCountMin = CustomOption.Create(300, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小船员个数"), 0f, 0f, 15f, 1f, null, true);
            crewmateRolesCountMax = CustomOption.Create(301, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大船员个数"), 0f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(302, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小中立个数"), 0f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(303, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大中立个数"), 0f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(304, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小伪装者数"), 0f, 0f, 3f, 1f);
            impostorRolesCountMax = CustomOption.Create(305, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大伪装者数"), 0f, 0f, 3f, 1f);

            mafiaSpawnRate = CustomOption.Create(10, cs(Janitor.color, "黑手党"), rates, null, true);
            janitorCooldown = CustomOption.Create(11, "清理者冷却", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(20, cs(Morphling.color, "变形者"), rates, null, true);
            morphlingCooldown = CustomOption.Create(21, "变形冷却", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(22, "变形持续时间", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

            camouflagerSpawnRate = CustomOption.Create(30, cs(Camouflager.color, "隐蔽者"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(31, "隐蔽冷却", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(32, "隐蔽持续时间", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            vampireSpawnRate = CustomOption.Create(40, cs(Vampire.color, "吸血鬼"), rates, null, true);
            vampireKillDelay = CustomOption.Create(41, "吸血击杀延迟", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(42, "吸血鬼冷却", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(43, "可以在大蒜范围内使用击杀", true, vampireSpawnRate);

            eraserSpawnRate = CustomOption.Create(230, cs(Eraser.color, "抹除者"), rates, null, true);
            eraserCooldown = CustomOption.Create(231, "抹除冷却", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(232, "可以抹除任何人", false, eraserSpawnRate);

            tricksterSpawnRate = CustomOption.Create(250, cs(Trickster.color, "魔术师"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(251, "盒子冷却", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(252, "特殊熄灯冷却", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(253, "特殊熄灯持续时间", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(260, cs(Cleaner.color, "清洁者"), rates, null, true);
            cleanerCooldown = CustomOption.Create(261, "清洁冷却", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(270, cs(Cleaner.color, "男巫"), rates, null, true);
            warlockCooldown = CustomOption.Create(271, "咒杀冷却", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(272, "咒杀定身时长", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(320, cs(BountyHunter.color, "赏金猎人"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(321, "猎物持续时长",  60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(322, "击杀正确目标冷却", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(323, "击杀错误目标增加冷却", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(324, "显示指向猎物的箭头", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(325, "箭头更新时间", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(370, cs(Witch.color, "女巫"), rates, null, true);
            witchCooldown = CustomOption.Create(371, "女巫下咒冷却", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(372, "女巫额外下咒冷却", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(373, "女巫可对任何人下咒", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(374, "施法时间", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(375, "与击杀共用冷却", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(376, "投出女巫会救下所有下咒目标", true, witchSpawnRate);

            miniSpawnRate = CustomOption.Create(180, cs(Mini.color, "小孩"), rates, null, true);
            miniGrowingUpDuration = CustomOption.Create(181, "小孩长大需要时间", 400f, 100f, 1500f, 100f, miniSpawnRate);

            loversSpawnRate = CustomOption.Create(50, cs(Lovers.color, "恋人"), rates, null, true);
            loversImpLoverRate = CustomOption.Create(51, "其中有恋人是伪装者概率", rates, loversSpawnRate);
            loversBothDie = CustomOption.Create(52, "恋人同生共死", true, loversSpawnRate);
            loversCanHaveAnotherRole = CustomOption.Create(53, "恋人可以拥有其他职业", true, loversSpawnRate);
            loversEnableChat = CustomOption.Create(54, "恋人可在会议外单独聊天", true, loversSpawnRate);

            guesserSpawnRate = CustomOption.Create(310, cs(Guesser.color, "猜测者"), rates, null, true);
            guesserIsImpGuesserRate = CustomOption.Create(311, "猜测者是伪装者概率", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(312, "总猜测次数", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(313, "一次会议可猜多人", false, guesserSpawnRate);
            guesserShowInfoInGhostChat = CustomOption.Create(314, "灵魂可见猜测者猜测信息", true, guesserSpawnRate);
            guesserKillsThroughShield  = CustomOption.Create(315, "无视医生盾牌", true, guesserSpawnRate);
            guesserEvilCanKillSpy  = CustomOption.Create(316, "邪恶猜测者可猜测特工", true, guesserSpawnRate);
            guesserSpawnBothRate = CustomOption.Create(317, "正义猜测者与邪恶猜测者同时存在的概率", rates, guesserSpawnRate);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(318, "猜测者不能猜做完任务的告密者", true, guesserSpawnRate);

            jesterSpawnRate = CustomOption.Create(60, cs(Jester.color, "小丑"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(61, "小丑可以发起紧急会议", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(62, "小丑有伪装者视野", false, jesterSpawnRate);

            arsonistSpawnRate = CustomOption.Create(290, cs(Arsonist.color, "纵火犯"), rates, null, true);
            arsonistCooldown = CustomOption.Create(291, "纵火犯冷却", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(292, "纵火犯浇油时间", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(220, cs(Jackal.color, "豺狼"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(221, "豺狼团队击杀冷却", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(222, "豺狼招募跟班冷却", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(223, "豺狼可使用管道", true, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(224, "豺狼可以招募跟班", false, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(225, "豺狼死后跟班晋升豺狼", false, jackalSpawnRate);
            sidekickCanKill = CustomOption.Create(226, "跟班可击杀", false, jackalSpawnRate);
            sidekickCanUseVents = CustomOption.Create(227, "跟班可以跳管道", true, jackalSpawnRate);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(228, "由跟班晋升的豺狼可招募跟班", true, jackalSpawnRate);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(229, "豺狼可招募伪装者", true, jackalSpawnRate);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(430, "豺狼团队有伪装者视野", false, jackalSpawnRate);

            vultureSpawnRate = CustomOption.Create(340, cs(Vulture.color, "秃鹫"), rates, null, true);
            vultureCooldown = CustomOption.Create(341, "秃鹫冷却", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(342, "秃鹫需要吃掉的尸体数", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(343, "秃鹫可以跳管道", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(344, "显示指向尸体的箭头", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(350, cs(Lawyer.color, "律师"), rates, null, true);
            lawyerTargetKnows = CustomOption.Create(351, "委托人知道有律师", true, lawyerSpawnRate);
            lawyerWinsAfterMeetings = CustomOption.Create(352, "律师在若干次会议后会胜利", false, lawyerSpawnRate);
            lawyerNeededMeetings = CustomOption.Create(353, "律师胜利需要会议数", 5f, 1f, 15f, 1f, lawyerWinsAfterMeetings);
            lawyerVision = CustomOption.Create(354, "律师视野", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(355, "律师知道委托人职业", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(356, "起诉人空包弹冷却", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(357, "起诉人空包弹数量", 5f, 1f, 20f, 1f, lawyerSpawnRate);

            shifterSpawnRate = CustomOption.Create(70, cs(Shifter.color, "小偷"), rates, null, true);
            shifterShiftsModifiers = CustomOption.Create(71, "小偷可以偷得所有效果", false, shifterSpawnRate);

            mayorSpawnRate = CustomOption.Create(80, cs(Mayor.color, "市长"), rates, null, true);

            engineerSpawnRate = CustomOption.Create(90, cs(Engineer.color, "工程师"), rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(91, "可修理紧急任务次数", 1f, 1f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(92, "工程师在管道里时伪装者看到高亮", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(93, "工程师在管道里时豺狼团队看到高亮", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(100, cs(Sheriff.color, "警长"), rates, null, true);
            sheriffCooldown = CustomOption.Create(101, "警长冷却", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(102, "警长可以击杀中立阵营", false, sheriffSpawnRate);
            deputySpawnRate = CustomOption.Create(103, "警长有警员", rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(104, "警员手铐数量", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(105, "手铐冷却", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(106, "手铐持续时间", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(107, "警长警员都知道对方", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(108, "警员可以晋升为警长", new string[] { "否", "是（立刻）", "是（会议）" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(109, "警员晋升警长保留手铐", true, deputyGetsPromoted);

            lighterSpawnRate = CustomOption.Create(110, cs(Lighter.color, "点灯者"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(111, "开灯时点灯视野", 2f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(112, "关灯时点灯视野", 0.75f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterCooldown = CustomOption.Create(113, "点灯冷却", 30f, 5f, 120f, 5f, lighterSpawnRate);
            lighterDuration = CustomOption.Create(114, "点灯持续时间", 5f, 2.5f, 60f, 2.5f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(120, cs(Detective.color, "侦探"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(121, "匿名脚印", false, detectiveSpawnRate); 
            detectiveFootprintIntervall = CustomOption.Create(122, "脚印间距", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(123, "脚印持续时间", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(124, "多少时间内报告会有凶手名字", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(125, "多少时间内报告会有颜色类型", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(130, cs(TimeMaster.color, "时间之主"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(131, "时间之盾冷却", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(132, "回溯时间", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(133, "时间之盾持续时间", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

            medicSpawnRate = CustomOption.Create(140, cs(Medic.color, "医生"), rates, null, true);
            medicShowShielded = CustomOption.Create(143, "护盾可见性", new string[] {"所有人", "医生与目标", "仅医生"}, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(144, "目标可见尝试击杀", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(145, "护盾下一次会议生效", false, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(146, "医生可见尝试击杀", false, medicSpawnRate);

            swapperSpawnRate = CustomOption.Create(150, cs(Swapper.color, "换票师"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(151, "换票师可以发起紧急会议", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(152, "换票师仅可交换其他人得票", false, swapperSpawnRate);

            seerSpawnRate = CustomOption.Create(160, cs(Seer.color, "占卜师"), rates, null, true);
            seerMode = CustomOption.Create(161, "占卜师能力", new string[]{ "可见闪光与灵魂", "可见闪光", "可见灵魂"}, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(163, "灵魂会随时间而消失", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(162, "灵魂隔多少时间消失", 15f, 0f, 120f, 5f, seerLimitSoulDuration);
        
            hackerSpawnRate = CustomOption.Create(170, cs(Hacker.color, "黑客"), rates, null, true);
            hackerCooldown = CustomOption.Create(171, "黑客冷却", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(172, "黑客持续时间", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(173, "只可见颜色类型", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(174, "随身工具电量上限", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(175, "完成多少任务来给随身工具充电", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(176, "使用随身工具时不可移动", true, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(200, cs(Tracker.color, "跟踪者"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(201, "箭头更新间隔", 5f, 1f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(202, "会议后重置目标", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(203, "跟踪者可跟踪尸体", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(204, "跟踪尸体冷却", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(205, "跟踪尸体持续时间", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
                           
            snitchSpawnRate = CustomOption.Create(210, cs(Snitch.color, "告密者"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(211, "告密者剩多少任务会暴露", 1f, 0f, 5f, 1f, snitchSpawnRate);
            snitchIncludeTeamJackal = CustomOption.Create(212, "告密者会知道豺狼团队", false, snitchSpawnRate);
            snitchTeamJackalUseDifferentArrowColor = CustomOption.Create(213, "豺狼团队的箭头使用不同颜色", true, snitchIncludeTeamJackal);

            spySpawnRate = CustomOption.Create(240, cs(Spy.color, "特工"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(241, "可以被警长处决", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(242, "有特工时伪装者可击杀任何人", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(243, "特工可以跳管道", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(244, "特工拥有伪装者视野", false, spySpawnRate);

            securityGuardSpawnRate = CustomOption.Create(280, cs(SecurityGuard.color, "安保人员"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(281, "安保冷却", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(282, "螺丝数量", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(283, "监控所需螺丝数", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(284, "封管道所需螺丝数", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(285, "随身监控持续时间", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(286, "随身监控电量上限", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(287, "完成多少任务来给随身监控充电", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(288, "使用随身监控时不可移动", true, securityGuardSpawnRate);

            baitSpawnRate = CustomOption.Create(330, cs(Bait.color, "诱饵"), rates, null, true);
            baitHighlightAllVents = CustomOption.Create(331, "有人在管道时高亮管道组而不是单个管道", false, baitSpawnRate);
            baitReportDelay = CustomOption.Create(332, "被迫报告延迟", 0f, 0f, 10f, 1f, baitSpawnRate);
            baitShowKillFlash = CustomOption.Create(333, "杀手击杀时会看到闪光提示", true, baitSpawnRate);

            mediumSpawnRate = CustomOption.Create(360, cs(Medium.color, "通灵师"), rates, null, true);
            mediumCooldown = CustomOption.Create(361, "通灵冷却", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(362, "通灵持续时间", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(363, "每个灵魂只可通灵一次", false, mediumSpawnRate);

            // Other options
            maxNumberOfMeetings = CustomOption.Create(3, "总计会议次数（不包括市长会议）", 10, 0, 15, 1, null, true);
            blockSkippingInEmergencyMeetings = CustomOption.Create(4, "紧急会议可跳过", false);
            noVoteIsSelfVote = CustomOption.Create(5, "未投票等于票自己", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(6, "隐藏玩家名字", false);
            allowParallelMedBayScans = CustomOption.Create(7, "允许多人同时扫描", false);

            dynamicMap = CustomOption.Create(8, "使用随机地图（内含反转贝壳号）", false, null, false);
            dynamicMapEnableSkeld = CustomOption.Create(501, "包含 Skeld 贝壳号", true, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(502, "包含 Mira 米拉总部", true, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(503, "包含 Polus 波鲁斯", true, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(504, "包含 Airship 飞艇", true, dynamicMap, false);
            dynamicMapEnableDleks = CustomOption.Create(505, "包含 dlekS 反转贝壳号", false, dynamicMap, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new [] { (byte)RoleId.Warlock});
            blockedRolePairings.Add((byte)RoleId.Warlock, new [] { (byte)RoleId.Vampire});
            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            blockedRolePairings.Add((byte)RoleId.Vulture, new [] { (byte)RoleId.Cleaner});
            blockedRolePairings.Add((byte)RoleId.Cleaner, new [] { (byte)RoleId.Vulture});
            
        }
    }
}
