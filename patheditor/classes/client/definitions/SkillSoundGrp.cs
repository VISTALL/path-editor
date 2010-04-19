#region Using

using System.Collections.Generic;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * Tested:
 * - Hellbound [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class SkillsoundgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UNICODE RESERVED_sub;
        public UNICODE RESERVED_throw;
        public UNICODE expeffect_sound_1;
        public UNICODE expeffect_sound_2;
        public UNICODE expeffect_sound_3;
        public FLOAT expeffect_sound_rad_1;
        public FLOAT expeffect_sound_rad_2;
        public FLOAT expeffect_sound_rad_3;
        public FLOAT expeffect_sound_vol_1;
        public FLOAT expeffect_sound_vol_2;
        public FLOAT expeffect_sound_vol_3;
        public UNICODE fdarkelf_sub;
        public UNICODE fdarkelf_throw;
        public UNICODE fdwarf_sub;
        public UNICODE fdwarf_throw;
        public UNICODE felf_sub;
        public UNICODE felf_throw;
        public UNICODE ffighter_sub;
        public UNICODE ffighter_throw;
        public UNICODE fkamael_sub;
        public UNICODE fkamael_throw;
        public UNICODE fmagic_sub;
        public UNICODE fmagic_throw;
        public UNICODE forc_sub;
        public UNICODE forc_throw;
        public UNICODE fshaman_sub;
        public UNICODE fshaman_throw;
        public UNICODE mdarkelf_sub;
        public UNICODE mdarkelf_throw;
        public UNICODE mdwarf_sub;
        public UNICODE mdwarf_throw;
        public UNICODE melf_sub;
        public UNICODE melf_throw;
        public UNICODE mfighter_sub;
        public UNICODE mfighter_throw;
        public UNICODE mkamael_sub;
        public UNICODE mkamael_throw;
        public UNICODE mmagic_sub;
        public UNICODE mmagic_throw;
        public UNICODE morc_sub;
        public UNICODE morc_throw;
        public UNICODE mshaman_sub;
        public UNICODE mshaman_throw;
        public UNICODE shoteffect_sound_1;
        public UNICODE shoteffect_sound_2;
        public UNICODE shoteffect_sound_3;
        public FLOAT shoteffect_sound_rad_1;
        public FLOAT shoteffect_sound_rad_2;
        public FLOAT shoteffect_sound_rad_3;
        public FLOAT shoteffect_sound_vol_1;
        public FLOAT shoteffect_sound_vol_2;
        public FLOAT shoteffect_sound_vol_3;
        public UINT skill_id;
        public UINT skill_level;
        public FLOAT sound_rad;
        public FLOAT sound_vol;
        public UNICODE spelleffect_sound_1;
        public UNICODE spelleffect_sound_2;
        public UNICODE spelleffect_sound_3;
        public FLOAT spelleffect_sound_rad_1;
        public FLOAT spelleffect_sound_rad_2;
        public FLOAT spelleffect_sound_rad_3;
        public FLOAT spelleffect_sound_vol_1;
        public FLOAT spelleffect_sound_vol_2;
        public FLOAT spelleffect_sound_vol_3;
    }

    #endregion

    #region Parser

    public class Skillsoundgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new SkillsoundgrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new SkillsoundgrpInfo();
            info = (SkillsoundgrpInfo) base.ReadFieldValue(f, info, "skill_id", "fshaman_sub");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                info = (SkillsoundgrpInfo) base.ReadFieldValue(f, info, "mkamael_sub", "fkamael_sub");
            info = (SkillsoundgrpInfo) base.ReadFieldValue(f, info, "RESERVED_sub", "fshaman_throw");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                info = (SkillsoundgrpInfo) base.ReadFieldValue(f, info, "mkamael_throw", "fkamael_throw");
            info = (SkillsoundgrpInfo) base.ReadFieldValue(f, info, "RESERVED_throw", "sound_rad");
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            var info = (SkillsoundgrpInfo) infos[RecNo];
            base.WriteFieldValue(f, info, "skill_id", "fshaman_sub");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                base.WriteFieldValue(f, info, "mkamael_sub", "fkamael_sub");
            base.WriteFieldValue(f, info, "RESERVED_sub", "fshaman_throw");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                base.WriteFieldValue(f, info, "mkamael_throw", "fkamael_throw");
            base.WriteFieldValue(f, info, "RESERVED_throw", "sound_rad");
        }
    }

    #endregion
}