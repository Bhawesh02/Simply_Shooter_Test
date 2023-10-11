
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="NewProjectile",menuName ="ScriptableObject/NewProjectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    public ProjectileType ProjectileType;
    public float Speed;
    public bool HasAoeDamange;
    [HideInInspector]
    public float AoeRange;

    [CustomEditor(typeof(ProjectileScriptableObject))]
    public class ProjectileScriptableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ProjectileScriptableObject projectile = (ProjectileScriptableObject)target;
            if (projectile.HasAoeDamange == false)
                return;
            projectile.AoeRange = EditorGUILayout.FloatField("AOE Range",projectile.AoeRange);
        }
    }
}
