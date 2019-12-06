﻿//using System;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
//using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
//
//namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
//{
//    public partial class IcSkSEntityManager: IStructIcSkSEntityManager<IIcSkSEntity>
//    {
//        private FasterList<IIcSkSEntity> _entitys;
//
//        public FasterReadOnlyList<IIcSkSEntity> Entitys => _entitys.AsReadOnly();
//
//        public IBuffManager<IIcSkSEntity> BuffManager { get; }
//
//        private IStructBuffManager<IIcSkSEntity> SBuffManager => (IStructBuffManager<IIcSkSEntity>) BuffManager;
//
//        public IcSkSEntityManager(IBuffManager<IIcSkSEntity> buffManager)
//        {
//            this.BuffManager = buffManager;
//            _entitys = new FasterList<IIcSkSEntity>();
//        }
//
//        private int _id;
//
//        public IIcSkSEntity CreateEntity()
//        {
//            ++_id;
//
//            return CreateEntity(_id);
//        }
//
//        /// <summary>
//        /// 创建实体
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>如果已经存在将返回id为-1的实体</returns>
//        public IIcSkSEntity CreateEntity(int id)
//        {
//            IIcSkSEntity entity = id;
//
//            if (_checkEntity(entity))
//            {
//                return -1;
//            }
//            
//            _entitys.Add(entity);
//            SBuffManager.AddEntity(entity);
//            
//            return entity;
//        }
//
//        public bool DestroyEntity(int id)
//        {
//            return DestroyEntity((IIcSkSEntity) id);
//        }
//
//        public bool DestroyEntity(IIcSkSEntity entity)
//        {
//            if (!_checkEntity(entity))
//            {
//                return false;
//            }
//
//            _entitys.Remove(entity);
//            
//            SBuffManager.RemoveEntity(entity);
//
//            return true;
//        }
//
//        private bool _checkEntity(in IIcSkSEntity entity)
//        {
//            return _entitys.Contains(entity);
//        }
//
//        public void Update()
//        {
//            SBuffManager.Update();
//        }
//
//        public void AddBuff<T>(IIcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
//        {
//            if (!_checkEntity(entity))
//            {
//                return;
//            }
//            
//            SBuffManager.AddBuff(entity,buff);
//        }
//
//        public bool RemoveBuff<T>(IIcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
//        {
//            if (!_checkEntity(entity))
//            {
//                return false;
//            }
//            
//            return SBuffManager.RemoveBuff(entity, buff);
//        }
//
//        public bool HasBuff<T>(IIcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
//        {
//            if (!_checkEntity(entity))
//            {
//                return false;
//            }
//            
//            return SBuffManager.HasBuff(entity, buff);
//        }
//
//        public int GetEntityCount()
//        {
//            return _entitys.Count;
//        }
//
//        #region Cover
//
//        FasterReadOnlyList<IIcSkSEntity> IIcSkSEntityManager<IIcSkSEntity>.Entitys => throw new NotImplementedException();
//
//        IBuffManager<IIcSkSEntity> IIcSkSEntityManager<IIcSkSEntity>.BuffManager => throw new NotImplementedException();
//
//        IIcSkSEntity IIcSkSEntityManager<IIcSkSEntity>.CreateEntity()
//        {
//            throw new NotImplementedException();
//        }
//
//        IIcSkSEntity IIcSkSEntityManager<IIcSkSEntity>.CreateEntity(int id)
//        {
//            throw new NotImplementedException();
//        }
//
//        public bool DestroyEntity(IIcSkSEntity entity)
//        {
//            throw new NotImplementedException();
//        }
//
//        void IIcSkSEntityManager<IIcSkSEntity>.AddBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException();
//        }
//
//        bool IIcSkSEntityManager<IIcSkSEntity>.RemoveBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException();
//        }
//
//        bool IIcSkSEntityManager<IIcSkSEntity>.HasBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException();
//        }
//
//        void IStructIcSkSEntityManager<IIcSkSEntity>.AddBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            AddBuff((IIcSkSEntity)entity,buff);
//        }
//
//        bool IStructIcSkSEntityManager<IIcSkSEntity>.RemoveBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            return RemoveBuff((IIcSkSEntity)entity,buff);
//        }
//
//        bool IStructIcSkSEntityManager<IIcSkSEntity>.HasBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            return RemoveBuff((IIcSkSEntity)entity,buff);
//        }
//
//        void IIcSkSEntityManager<IIcSkSEntity>.AddBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IIcSkSEntity>)}");
//        }
//
//        bool IIcSkSEntityManager<IIcSkSEntity>.RemoveBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IIcSkSEntity>)}");
//        }
//
//        bool IIcSkSEntityManager<IIcSkSEntity>.HasBuff<T>(IIcSkSEntity entity, T buff)
//        {
//            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IIcSkSEntity>)}");
//        }
//
//        #endregion
//    }
//}