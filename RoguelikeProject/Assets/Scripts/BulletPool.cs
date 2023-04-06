using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{ 
    private List<Bullet> _pool = new List<Bullet>();

    public void Init(Bullet prefab, int count, int damage, Transform conteiner)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(prefab, conteiner);

            bullet.gameObject.SetActive(false);
            bullet.SetDamage(damage);

            _pool.Add(bullet);
        }
    }

    public bool TryGetBullet(out Bullet bullet)
    {
        bullet = _pool.First(p => p.gameObject.activeSelf == false);

        return bullet != null;
    }
}
