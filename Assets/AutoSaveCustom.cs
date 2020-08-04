using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using BayatGames.SaveGameFree.Encoders;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree.Types;


  
//namespace BayatGames.SaveGameFree
//{
//    public class AutoSaveCustom : MonoBehaviour
//    {
//        /// <summary>
//        /// Save Game Auto.
//        /// Make your game objects save their position, rotaiton and scale automatically.
//        /// </summary>
//        //[AddComponentMenu("Save Game Free/Auto Save")]
//    public class SaveGameAuto : MonoBehaviour
//    {

//        /// <summary>
//        /// Save format.
//        /// </summary>
//        public enum SaveFormat
//        {

//            /// <summary>
//            /// The XML.
//            /// </summary>
//            XML,

//            /// <summary>
//            /// The JSON.
//            /// </summary>
//            JSON,

//            /// <summary>
//            /// The Ninary.
//            /// </summary>
//            Binary

//        }


//        [Header("Settings")]
//        [Space]

//        [Tooltip("Encode the data?")]
//        /// <summary>
//        /// The encode.
//        /// </summary>
//        public bool encode = false;

//        [Tooltip("If you leave it blank this will reset to it's default value.")]
//        /// <summary>
//        /// The encode password.
//        /// </summary>
//        public string encodePassword = "";

//        [Tooltip("Which serialization format?")]
//        public SaveFormat format = SaveFormat.JSON;

//        [Tooltip("If you leave it blank this will reset to it's default value.")]
//        /// <summary>
//        /// The serializer.
//        /// </summary>
//        public ISaveGameSerializer serializer;

//        [Tooltip("If you leave it blank this will reset to it's default value.")]
//        /// <summary>
//        /// The encoder.
//        /// </summary>
//        public ISaveGameEncoder encoder;

//        [Tooltip("If you leave it blank this will reset to it's default value.")]
//        /// <summary>
//        /// The encoding.
//        /// </summary>
//        public Encoding encoding;

//        [Tooltip("Where to save? (PersistentDataPath highly recommended).")]
//        /// <summary>
//        /// The save path.
//        /// </summary>
//        public SaveGamePath savePath = SaveGamePath.PersistentDataPath;

//        [Tooltip("Reset the empty fields to their default value.")]
//        /// <summary>
//        /// The reset blanks.
//        /// </summary>
//        public bool resetBlanks = true;


//        //Saving the things that I want

//        [Header("Save Events")]
//        [Space]


//        [Tooltip("Save on Awake()")]
//        /// <summary>
//        /// The save on awake.
//        /// </summary>
//        public bool saveOnAwake;

//        [Tooltip("Save on Start()")]
//        /// <summary>
//        /// The save on start.
//        /// </summary>
//        public bool saveOnStart;

//        [Tooltip("Save on OnEnable()")]
//        /// <summary>
//        /// The save on enable.
//        /// </summary>
//        public bool saveOnEnable;

//        [Tooltip("Save on OnDisable()")]
//        /// <summary>
//        /// The save on disable.
//        /// </summary>
//        public bool saveOnDisable = true;

//        [Tooltip("Save on OnApplicationQuit()")]
//        /// <summary>
//        /// The save on application quit.
//        /// </summary>
//        public bool saveOnApplicationQuit = true;

//        [Tooltip("Save on OnApplicationPause()")]
//        /// <summary>
//        /// The save on application pause.
//        /// </summary>
//        public bool saveOnApplicationPause;


//        [Header("Load Events")]
//        [Space]


//        [Tooltip("Load on Awake()")]
//        /// <summary>
//        /// The load on awake.
//        /// </summary>
//        public bool loadOnAwake;

//        [Tooltip("Load on Start()")]
//        /// <summary>
//        /// The load on start.
//        /// </summary>
//        public bool loadOnStart = true;

//        [Tooltip("Load on OnEnable()")]
//        /// <summary>
//        /// The load on enable.
//        /// </summary>
//        public bool loadOnEnable = false;

//        protected virtual void Awake()
//        {
//            if (resetBlanks)
//            {
//                if (string.IsNullOrEmpty(encodePassword))
//                {
//                    encodePassword = SaveGame.EncodePassword;
//                }
//                if (serializer == null)
//                {
//                    serializer = SaveGame.Serializer;
//                }
//                if (encoder == null)
//                {
//                    encoder = SaveGame.Encoder;
//                }
//                if (encoding == null)
//                {
//                    encoding = SaveGame.DefaultEncoding;
//                }
//            }
//            switch (format)
//            {
//                case SaveFormat.Binary:
//                    serializer = new SaveGameBinarySerializer();
//                    break;
//                case SaveFormat.JSON:
//                    serializer = new SaveGameJsonSerializer();
//                    break;
//                case SaveFormat.XML:
//                    serializer = new SaveGameXmlSerializer();
//                    break;
//            }
//            if (loadOnAwake)
//            {
//                Load();
//            }
//            if (saveOnAwake)
//            {
//                Save();
//            }
//        }

//        protected virtual void Start()
//        {
//            if (loadOnStart)
//            {
//                Load();
//            }
//            if (saveOnStart)
//            {
//                Save();
//            }
//        }

//        protected virtual void OnEnable()
//        {
//            if (loadOnEnable)
//            {
//                Load();
//            }
//            if (saveOnEnable)
//            {
//                Save();
//            }
//        }

//        protected virtual void OnDisable()
//        {
//            if (saveOnDisable)
//            {
//                Save();
//            }
//        }

//        protected virtual void OnApplicationQuit()
//        {
//            if (saveOnApplicationQuit)
//            {
//                Save();
//            }
//        }

//        protected virtual void OnApplicationPause()
//        {
//            if (saveOnApplicationPause)
//            {
//                Save();
//            }
//        }

//        /// <summary>
//        /// Save this instance.
//        /// </summary>
//        public virtual void Save()
//        {
           
//            if (saveScale)
//            {
//                SaveGame.Save<Vector3Save>(
//                    scaleIdentifier,
//                    transform.localScale,
//                    encode,
//                    encodePassword,
//                    serializer,
//                    encoder,
//                    encoding,
//                    savePath);
//            }
//        }

//        /// <summary>
//        /// Load this instance.
//        /// </summary>
//        public virtual void Load()
//        {
           
//            if (saveScale)
//            {
//                transform.localScale = SaveGame.Load<Vector3Save>(
//                    scaleIdentifier,
//                    defaultScale,
//                    encode,
//                    encodePassword,
//                    serializer,
//                    encoder,
//                    encoding,
//                    savePath);
//            }
//        }

//    }

//}
//}
