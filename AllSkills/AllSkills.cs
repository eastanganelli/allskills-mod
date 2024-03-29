﻿using System;
using System.Reflection;
using Modding;
using Skills;

namespace AllSkills {
    public class AllSkills : Mod {
        private const string version = "1.5.78-Rev3";
        private Skills.Skills Skills_ = new Skills.Skills();
        public override void Initialize() {
            ModHooks.SetPlayerBoolHook += PlayerBoolSet;
        }
        private bool PlayerBoolSet(string target, bool value) {
            PlayerData.instance.SetBoolInternal(target, value);
            
            try {
                Skills_.UpdateSkillValues(PlayerData.instance);
                Log("Skills updated.");
            }
            catch(Exception Ex) {
                Log(Ex.ToString());
            }

            return value;
        }
        public override string GetVersion() => version;
    }
}
