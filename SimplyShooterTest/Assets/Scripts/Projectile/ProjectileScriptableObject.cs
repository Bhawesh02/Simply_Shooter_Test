
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="NewProjectile",menuName ="ScriptableObject/NewProjectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    [field: SerializeField]
    public ProjectileType ProjectileType { get; private set; }
    [field: SerializeField]
    public float Speed { get; private set; }
    [field: SerializeField]
    public bool HasAoeDamange { get; private set; }
    [HideInInspector]
    public float AoeRange { get; private set; }

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
