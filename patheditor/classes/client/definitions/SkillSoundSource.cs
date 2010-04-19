using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

/**
 * Tested:
 * - Freya [WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class SkillSoundSourceInfo : Definition
    {
        public UINT skill_id;
        public UINT unk_0;
        public UINT unk_2;
        public UINT unk_3;
        public UINT unk_4;
        public UINT unk_5;
        public UINT unk_6;
        public UINT unk_7;
        public UINT unk_8;
        public UINT unk_9;
    }

    #endregion

    #region Parser

    public class SkillSoundSource : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Freya)
                return new SkillSoundSourceInfo();

            return null;
        }
    }

    #endregion
}