using System;
using System.Text;

namespace AssetsTools.NET.Unity
{
    public struct Type_0D
    {
        public int classId;

        public byte unknown16_1;
        public ushort scriptIndex;
        
        public uint unknown1;
        public uint unknown2;
        public uint unknown3;
        public uint unknown4;
        
        public uint unknown5;
        public uint unknown6;
        public uint unknown7;
        public uint unknown8;
        public uint typeFieldsExCount;
        public TypeField_0D[] pTypeFieldsEx;

        public uint stringTableLen;
        public string[] pStringTable;

        public ulong Read(bool hasTypeTree, ulong absFilePos, AssetsFileReader reader, uint version, uint typeVersion, bool bigEndian)
        {
            classId = reader.ReadInt32();
            if (version >= 0x10) unknown16_1 = reader.ReadByte();
            if (version >= 0x11) scriptIndex = reader.ReadUInt16();
            if ((version < 0x11 && classId < 0) || (version >= 0x11 && scriptIndex != 0xFFFF))
            {
                unknown1 = reader.ReadUInt32();
                unknown2 = reader.ReadUInt32();
                unknown3 = reader.ReadUInt32();
                unknown4 = reader.ReadUInt32();
            }
            unknown5 = reader.ReadUInt32();
            unknown6 = reader.ReadUInt32();
            unknown7 = reader.ReadUInt32();
            unknown8 = reader.ReadUInt32();
            if (hasTypeTree)
            {
                typeFieldsExCount = reader.ReadUInt32();
                stringTableLen = reader.ReadUInt32();
                pTypeFieldsEx = new TypeField_0D[typeFieldsExCount];
                for (int i = 0; i < typeFieldsExCount; i++)
                {
                    TypeField_0D typefield0d = new TypeField_0D();
                    typefield0d.Read(reader.Position, reader, bigEndian);
                    pTypeFieldsEx[i] = typefield0d;
                }
                string rawStringTable = Encoding.UTF8.GetString(reader.ReadBytes((int)stringTableLen));
                pStringTable = rawStringTable.Split('\0');
                Array.Resize(ref pStringTable, pStringTable.Length - 1);
            }
            return reader.Position;
        }
        //0x28212B0
        public static readonly string strTable = "AABB.AnimationClip.AnimationCurve.AnimationState.Array.Base.BitField.bitset.bool.char.ColorRGBA.Component.data.deque.double.dynamic_array.FastPropertyName.first.float.Font.GameObject.Generic Mono.GradientNEW.GUID.GUIStyle.int.list.long long.map.Matrix4x4f.MdFour.MonoBehaviour.MonoScript.m_ByteSize.m_Curve.m_EditorClassIdentifier.m_EditorHideFlags.m_Enabled.m_ExtensionPtr.m_GameObject.m_Index.m_IsArray.m_IsStatic.m_MetaFlag.m_Name.m_ObjectHideFlags.m_PrefabInternal.m_PrefabParentObject.m_Script.m_StaticEditorFlags.m_Type.m_Version.Object.pair.PPtr<Component>.PPtr<GameObject>.PPtr<Material>.PPtr<MonoBehaviour>.PPtr<MonoScript>.PPtr<Object>.PPtr<Prefab>.PPtr<Sprite>.PPtr<TextAsset>.PPtr<Texture>.PPtr<Texture2D>.PPtr<Transform>.Prefab.Quaternionf.Rectf.RectInt.RectOffset.second.set.short.size.SInt16.SInt32.SInt64.SInt8.staticvector.string.TextAsset.TextMesh.Texture.Texture2D.Transform.TypelessData.UInt16.UInt32.UInt64.UInt8.unsigned int.unsigned long long.unsigned short.vector.Vector2f.Vector3f.Vector4f.m_ScriptingClassIdentifier.Gradient.Type*";
    }
}
