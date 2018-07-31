using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes;

namespace Mirror.Talent
{
    public class Commands : Script
    {
        [Command("checksheet")]
        public void SkillCheck(Client client)
        {
            if (Settings.Settings.DisableTalentCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            client.SendChatMessage($"=== ~b~SHEET ~w~===");
            client.SendChatMessage($"~g~END: ~w~{sheet.Endurance} > +{sheet.GetEndScore()} Modifier");
            client.SendChatMessage($"~r~STR: ~w~{sheet.Strength} > +{sheet.GetStrScore()} Modifier");
            client.SendChatMessage($"~b~INT: ~w~{sheet.Intelligence} > +{sheet.GetIntScore()} Modifier");
            client.SendChatMessage($"~o~CHA: ~w~{sheet.Charisma} > +{sheet.GetChaScore()} Modifier");
        }

        [Command("checkdebuffs")]
        public void DebuffCheck(Client client)
        {
            if (Settings.Settings.DisableTalentCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            client.SendChatMessage($"=== ~b~Debuffs ~w~===");
            client.SendChatMessage($"~g~END: ~w~{sheet.EnduranceModifier}");
            client.SendChatMessage($"~r~STR: ~w~{sheet.StrengthModifier}");
            client.SendChatMessage($"~b~INT: ~w~{sheet.IntelligenceModifier}");
            client.SendChatMessage($"~o~CHA: ~w~{sheet.CharismaModifier}");
        }

        [Command("restoredebuffs")]
        public void RestoreDebuffs(Client client)
        {
            if (Settings.Settings.DisableTalentCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            sheet.RestoreModifiers();

            client.SendChatMessage("~g~Debuffs have been cleared.");
        }

        [Command("loadsheet")]
        public void GetTalentSheet(Client client)
        {
            if (Settings.Settings.DisableTalentCommands)
                return;

            CharacterGen.LoadTalentSheet(client);
            client.SendChatMessage("[Talent] Loaded. Use /checksheet");
        }

        [Command("savesheet")]
        public void SaveTalentSheet(Client client)
        {
            if (Settings.Settings.DisableTalentCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            sheet.SaveNewScoresheet();
            client.SendChatMessage("[Talent] Saved. Use /checksheet");
        }
    }
}
