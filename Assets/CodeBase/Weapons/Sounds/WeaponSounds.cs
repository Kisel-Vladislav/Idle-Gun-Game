using CodeBase.Infrastructure.Services.Audio;
using CodeBase.StaticData.Weapon;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Weapons.Sounds
{
    public class WeaponSounds
    {
        private readonly IAudioService _audioService;
        private readonly Dictionary<WeaponSoundType, AudioClip> _weaponClips;

        public WeaponSounds(WeaponAudioData audioData, IAudioService audioService)
        {
            _weaponClips = audioData.AudioClips.ToDictionary(x => x.SoundType, x => x.Clip);
            _audioService = audioService;
        }

        public void Play(WeaponSoundType soundType) =>
            _audioService.Play(_weaponClips[soundType]);
    }
}
