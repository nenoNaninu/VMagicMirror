﻿using System;
using System.Linq;
using UnityEngine;

namespace Baku.VMagicMirror
{
    /// <summary>
    /// 単語一覧とモーションのマッピングを管理するクラス
    /// </summary>
    /// <remarks>
    /// 機能上はMonoBehaviorの必然性があまりないが、陽に組み込みクリップ一覧が定義できて良いのでこうしている。
    /// </remarks>
    public class WordToMotionMapper : MonoBehaviour
    {
        [Serializable]
        class BuiltInAnimationClip
        {
            public string name = "";
            public AnimationClip clip = null;
        }

        [SerializeField] private BuiltInAnimationClip[] builtInClips = null;

        //note: アロケーション都合で配列として公開するが、他所からは書きかえない想定
        public MotionRequest[] Requests { get; set; } = new MotionRequest[0];

        /// <summary>
        /// 起動のきっかけになる単語を指定してモーション要素を取得します。
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public MotionRequest FindMotionRequest(string word)
            => Requests?.FirstOrDefault(r => r.Word == word);

        /// <summary>
        /// インデックスを指定してモーション要素を取得します。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MotionRequest FindMotionByIndex(int index)
            => (Requests != null && index >= 0 && index < Requests.Length) ? Requests[index] : null;

        /// <summary>
        /// ビルトインアニメーションを、名称を指定して取得します。
        /// </summary>
        /// <param name="clipName"></param>
        /// <returns></returns>
        public AnimationClip FindBuiltInAnimationClipOrDefault(string clipName)
        {
            Debug.Log("Requested clip name = " + clipName);
            for (int i = 0; i < builtInClips.Length; i++)
            {
                if (builtInClips[i].name == clipName)
                {
                    return builtInClips[i].clip;
                }
            }
            return null;
        }

        //NOTE: Bvhは一旦ここでハンドルしないようにしてみる(ここに実装足してもOK)
    }
}
