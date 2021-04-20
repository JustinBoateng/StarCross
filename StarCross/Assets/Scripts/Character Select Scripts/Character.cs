using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New CharacterCSS, menuName = Character")]
public class Character : ScriptableObject
{
    public Sprite Icon;
    public Sprite MiniIcon;
    public Sprite BattleIcon;
    public Sprite[][] SpriteInfo;
    public string Name;
    public Sprite Logo;


}
