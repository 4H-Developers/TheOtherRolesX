using HarmonyLib;
using System.Linq;
using System;
using System.Collections.Generic;
using static TheOtherRoles.TheOtherRoles;
using UnityEngine;

namespace TheOtherRoles
{
    class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;

        RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
        }

        public static RoleInfo jester = new RoleInfo("小丑", Jester.color, "被票出去", "被票出去", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("市长", Mayor.color, "你的票算两次", "你的票算两次", RoleId.Mayor);
        public static RoleInfo engineer = new RoleInfo("工程师",  Engineer.color, "管理飞船上的设备", "管理飞船", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("警长", Sheriff.color, "把<color=#FF1919FF>伪装者</color>一枪毙了", "把伪装者毙了", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("警员", Sheriff.color, "给<color=#FF1919FF>伪装者</color>戴上手铐", "戴上手铐", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("点灯者", Lighter.color, "你就是最亮的光", "你就是最亮的光", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("教父（黑手党）", Godfather.color, "杀光<color=#FF1919FF>船员</color>", "杀光船员", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("小弟（黑手党）", Mafioso.color, "跟随<color=#FF1919FF>教父</color>杀光船员", "杀光船员", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("清理者（黑手党）", Janitor.color, "跟随<color=#FF1919FF>教父</color>清理尸体", "清理尸体", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("变形者", Morphling.color, "变换外观以避免被发现", "变换外观", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("隐蔽者", Camouflager.color, "隐蔽并杀掉<color=#FF1919FF>船员</color>", "隐蔽起来", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("吸血鬼", Vampire.color, "咬一口<color=#FF1919FF>船员</color>", "咬船员", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("抹除者", Eraser.color, "抹掉<color=#FF1919FF>船员</color>的职业", "抹掉职业", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("魔术师", Trickster.color, "放置盒子来给<color=#FF1919FF>船员</color>带来惊喜", "给船员带来惊喜", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("清洁者", Cleaner.color, "清理掉尸体以免被发现", "清理尸体", RoleId.Cleaner);
        public static RoleInfo warlock = new RoleInfo("男巫", Warlock.color, "咒杀<color=#FF1919FF>船员</color>", "咒杀船员", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("赏金猎人", BountyHunter.color, "找到你的<color=#FF1919FF>猎物</color>", "找到你的猎物", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("侦探", Detective.color, "观察脚印与尸检报告来找出<color=#FF1919FF>伪装者</color>", "观察脚印", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("时间之主", TimeMaster.color, "时间之盾可以保护你", "时间之盾可以保护你", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("医生", Medic.color, "用你的盾保护其他人", "用盾保护其他人", RoleId.Medic);
        public static RoleInfo shifter = new RoleInfo("小偷", Shifter.color, "偷走别人的职业", "偷走职业", RoleId.Shifter);
        public static RoleInfo swapper = new RoleInfo("换票师", Swapper.color, "交换得票以票出<color=#FF1919FF>伪装者</color>", "交换得票", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("占卜师", Seer.color, "你能预测到玩家死亡", "你能预测到玩家死亡", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("黑客", Hacker.color, "启用黑客技能找到<color=#FF1919FF>伪装者</color>", "启用黑客技能找到伪装者", RoleId.Hacker);
        public static RoleInfo niceMini = new RoleInfo("乖小孩", Mini.color, "长大之前谁也不能伤害你", "长大之前谁也不能伤害你", RoleId.Mini);
        public static RoleInfo evilMini = new RoleInfo("坏小孩", Palette.ImpostorRed, "长大之前谁也不能伤害你", "长大之前谁也不能伤害你", RoleId.Mini);
        public static RoleInfo tracker = new RoleInfo("跟踪者", Tracker.color, "启用跟踪找到<color=#FF1919FF>伪装者</color>", "启用跟踪", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("告密者", Snitch.color, "完成任务找到<color=#FF1919FF>伪装者</color>", "完成任务", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("豺狼", Jackal.color, "把<color=#FF1919FF>船员与伪装者</color>都杀光", "都杀光", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("跟班", Sidekick.color, "跟豺狼一起打遍天下", "跟豺狼一起打遍天下", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("特工", Spy.color, "潜伏在<color=#FF1919FF>伪装者</color>之中", "潜伏在伪装者之中", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("安保人员", SecurityGuard.color, "堵住通风口和安装监控", "堵住通风口和安装监控", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("纵火犯", Arsonist.color, "博人传是不可燃物", "博人传是不可燃物", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("正义猜测者", Guesser.color, "猜出<color=#FF1919FF>伪装者</color>", "猜出伪装者", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("邪恶猜测者", Palette.ImpostorRed, "猜出<color=#FF1919FF>船员</color>", "猜出船员", RoleId.EvilGuesser);
        public static RoleInfo bait = new RoleInfo("诱饵", Bait.color, "诱惑<color=#FF1919FF>伪装者</color>", "诱惑伪装者", RoleId.Bait);
        public static RoleInfo vulture = new RoleInfo("秃鹫", Vulture.color, "吃尸体来获取胜利", "吃尸体", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("通灵师", Medium.color, "通灵以获取有用的信息", "通灵以获取有用的信息", RoleId.Medium);
        public static RoleInfo lawyer = new RoleInfo("律师", Lawyer.color, "为你的<color=#FF1919FF>委托人</color>辩护", "为委托人辩护", RoleId.Lawyer, true);
        public static RoleInfo pursuer = new RoleInfo("起诉人", Pursuer.color, "给<color=#FF1919FF>伪装者</color>塞空包弹", "塞空包弹", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("伪装者", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "破坏并杀掉<color=#FF1919FF>所有人</color>"), "破坏并杀掉所有人", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("船员", Color.white, "找出<color=#FF1919FF>伪装者</color>", "找出伪装者", RoleId.Crewmate);
        public static RoleInfo lover = new RoleInfo("恋人", Lovers.color, $"你坠入了爱河", $"你坠入了爱河", RoleId.Lover);
        public static RoleInfo witch = new RoleInfo("女巫", Witch.color, "给<color=#FF1919FF>船员</color>下咒", "给船员下咒", RoleId.Witch);

        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            niceMini,
            evilMini,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            crewmate,
            shifter,
            mayor,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Shifter.shifter) infos.Add(shifter);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Mini.mini) infos.Add(p.Data.Role.IsImpostor ? evilMini : niceMini);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Bait.bait) infos.Add(bait);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer) infos.Add(lawyer);
            if (p == Pursuer.pursuer) infos.Add(pursuer);

            // Default roles
            if (infos.Count == 0 && p.Data.Role.IsImpostor) infos.Add(impostor); // Just Impostor
            if (infos.Count == 0 && !p.Data.Role.IsImpostor) infos.Add(crewmate); // Just Crewmate

            // Modifier
            if (p == Lovers.lover1|| p == Lovers.lover2) infos.Add(lover);

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors) {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && PlayerControl.LocalPlayer != Lawyer.target) roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            return roleName;
        }
    }
}
