using System;
using System.Data;
using System.Collections;
using System.Text;
using Phitakphong.LEKCommon;
using Phitakphong.LEKDbMgr;

namespace Phitakphong.Makeup.Common {
	/// <summary>
	/// Entity class for GoodsGroup.
	/// </summary>
 	public class GoodsGroup : ILEKEntity  {

		#region DataMembers
		private int _GroupID;
		private string _GroupName;
		private bool _IsActive;
		private int _TypeID;
		private GoodsType _type;
		private DateTime _CreateTime;
		private int _CreateBy;
		private DateTime _UpdateTime;
		private int _UpdateBy;

		#endregion

		#region Constructor
		public GoodsGroup() {
		}

		public GoodsGroup(int pGroupID) {
			this.open(pGroupID);
		}
		
		public GoodsGroup(int pGroupID, IConnection pConn) {
			this.open(pGroupID, pConn);
		}
		#endregion

		#region Properties
		public bool IsDBExist{
			get{
				return (_GroupID > 0);
			}
		}

		public int GroupID{
			get {
				return _GroupID;
			}
		}

		public string GroupName{
			get {
				return _GroupName;
			}
			set {
				_GroupName= value;
			}
		}

		public bool IsActive{
			get {
				return _IsActive;
			}
			set {
				_IsActive= value;
			}
		}

		public GoodsType type{
			get {
				if (_type==null){
					if (_TypeID == 0)
						return null;
					_type = new GoodsType(_TypeID);
				}
				return _type;
			}
			set {
				_type = value;
				_TypeID = _type.TypeID;
			}
		}

		public int TypeID{
			set {
				_TypeID = value;
				_type = null;
			}
			get {
				return _TypeID;
			}
		}

		public DateTime CreateTime{
			get {
				return _CreateTime;
			}
			set {
				_CreateTime= value;
			}
		}

		public int CreateBy{
			set {
				_CreateBy = value;
			}
			get {
				return _CreateBy;
			}
		}

		public DateTime UpdateTime{
			get {
				return _UpdateTime;
			}
		}

		public int UpdateBy{
			set {
				_UpdateBy = value;
			}
			get {
				return _UpdateBy;
			}
		}


		#endregion

		#region Method
		public void BindData(DataRow pRow){
			_GroupID = LEKConvert.ToInt(pRow["GroupID"]);
			_GroupName = LEKConvert.ToString(pRow["GroupName"]);
			_IsActive = LEKConvert.ToBool(pRow["IsActive"]);
			_TypeID = LEKConvert.ToInt(pRow["TypeID"]);
			_CreateTime = LEKConvert.ToDateTime(pRow["CreateTime"]);
			_CreateBy = LEKConvert.ToInt(pRow["CreateBy"]);
			_UpdateTime = LEKConvert.ToDateTime(pRow["UpdateTime"]);
			_UpdateBy = LEKConvert.ToInt(pRow["UpdateBy"]);

		}

		public void open(int pGroupID) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_groups WHERE GroupID = " +  pGroupID.ToString() ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "GroupID = " +  pGroupID.ToString() );
		}

		public void open(int pGroupID, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_groups WHERE GroupID = " +  pGroupID.ToString() ;
			DataTable Tbl = pConn.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "GroupID = " +  pGroupID.ToString() );
		}
		
		public bool openExist(int pGroupID) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_groups WHERE GroupID = " +  pGroupID.ToString() ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1){
				this.BindData(Tbl.Rows[0]);
				return true;
			}else
				return false;
		}
		
		public bool openExist(int pGroupID, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_groups WHERE GroupID = " +  pGroupID.ToString() ;
			DataTable Tbl = pConn.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1){
				this.BindData(Tbl.Rows[0]);
				return true;
			}else
				return false;
		}
		
		public int add(int pCreateUserID) {
			int result = 0;
            IConnection Conn = DbMgr.GetConnection();
            try {
				result = this.add(Conn, pCreateUserID);
			} catch (Exception ex) {
                throw ex;
            } finally {
                Conn.close();
            }
            return result;
		}

		public int add(IConnection pConn, int pCreateUserID) {
			this._CreateBy = pCreateUserID;
			this._UpdateBy = pCreateUserID;
			this._CreateTime = DateTime.Now;
			this._UpdateTime = DateTime.Now;
			string SqlStr;
			int result = 0;
			SqlStr = "INSERT INTO goods_groups(GroupName, IsActive, TypeID, CreateTime, CreateBy, UpdateTime, UpdateBy) VALUES(" + 
				DbMgr.formatDbString(_GroupName)  + 
				", " +  DbMgr.formatDbBool(_IsActive)  + 
				", " + DbMgr.formatDbID(_TypeID) + 
				", " + DbMgr.formatDbDateTime(_CreateTime) +
				", " + DbMgr.formatDbID(_CreateBy) + 
				", " + DbMgr.formatDbDateTime(_UpdateTime) +
				", " + DbMgr.formatDbID(_UpdateBy) + 
				")";
			result = pConn.exeInsertQuery(SqlStr,"goods_groups","GroupID");
			_GroupID = result;
			return result;
		}
		
		public int update(int pUpdateUserID) {
			int result = 0;
            IConnection Conn = DbMgr.GetConnection();
            try {
				result = this.update(Conn, pUpdateUserID);
			} catch (Exception ex) {
                throw ex;
            } finally {
                Conn.close();
            }
            return result;
		}

		public int update(IConnection pConn, int pUpdateUserID) {
			this._UpdateBy = pUpdateUserID;
			this._UpdateTime = DateTime.Now;
			string SqlStr;
			int result=0;
			SqlStr = " UPDATE goods_groups SET " + 
				" GroupName = " + DbMgr.formatDbString(_GroupName) + 
				" ,IsActive = " + DbMgr.formatDbBool(_IsActive) + 
				" ,TypeID = " + DbMgr.formatDbID(_TypeID) + 
				" ,UpdateTime = " + DbMgr.formatDbDateTime(_UpdateTime) + 
				" ,UpdateBy = " + DbMgr.formatDbID(_UpdateBy) + 
				" WHERE GroupID = " +  _GroupID.ToString() ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}
		
		public int delete() {
			int result = 0;
            IConnection Conn = DbMgr.GetConnection();
            try {
				result = this.delete(Conn);
			} catch (Exception ex) {
                throw ex;
            } finally {
                Conn.close();
            }
            return result;
		}
		
		public int delete(IConnection pConn) {
			string SqlStr;
			int result=0;
			SqlStr = " DELETE FROM goods_groups" + 
				" WHERE GroupID = " +  _GroupID.ToString() ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}
		
		public int deActive(int pUpdateUserID) {
			int result = 0;
            IConnection Conn = DbMgr.GetConnection();
            try {
				result = this.deActive(Conn, pUpdateUserID);
			} catch (Exception ex) {
                throw ex;
            } finally {
                Conn.close();
            }
            return result;
		}
				
		public int deActive(IConnection pConn, int pUpdateUserID) {
			this._UpdateBy = pUpdateUserID;
			string SqlStr;
			int result=0;
			SqlStr = "UPDATE goods_groups SET IsActive = 'N' " +
				" ,UpdateTime = " + DbMgr.formatDbGetDate() + 
				" ,UpdateBy = " + _UpdateBy.ToString() + 
				" WHERE GroupID = " +  _GroupID.ToString() ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}		
		#endregion
		
		#region Manual Code

		#endregion
	}
}
