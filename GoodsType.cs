using System;
using System.Data;
using System.Collections;
using System.Text;
using Phitakphong.LEKCommon;
using Phitakphong.LEKDbMgr;

namespace Phitakphong.Makeup.Common {
	/// <summary>
	/// Entity class for GoodsType.
	/// </summary>
 	public class GoodsType : ILEKEntity  {

		#region DataMembers
		private int _TypeID;
		private string _TypeName;
		private DateTime _CreateTime;
		private int _CreateBy;
		private DateTime _UpdateTime;
		private int _UpdateBy;

		#endregion

		#region Constructor
		public GoodsType() {
		}

		public GoodsType(int pTypeID) {
			this.open(pTypeID);
		}
		
		public GoodsType(int pTypeID, IConnection pConn) {
			this.open(pTypeID, pConn);
		}
		#endregion

		#region Properties
		public bool IsDBExist{
			get{
				return (_TypeID > 0);
			}
		}

		public int TypeID{
			get {
				return _TypeID;
			}
		}

		public string TypeName{
			get {
				return _TypeName;
			}
			set {
				_TypeName= value;
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
			_TypeID = LEKConvert.ToInt(pRow["TypeID"]);
			_TypeName = LEKConvert.ToString(pRow["TypeName"]);
			_CreateTime = LEKConvert.ToDateTime(pRow["CreateTime"]);
			_CreateBy = LEKConvert.ToInt(pRow["CreateBy"]);
			_UpdateTime = LEKConvert.ToDateTime(pRow["UpdateTime"]);
			_UpdateBy = LEKConvert.ToInt(pRow["UpdateBy"]);

		}

		public void open(int pTypeID) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_types WHERE TypeID = " +  pTypeID.ToString() ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "TypeID = " +  pTypeID.ToString() );
		}

		public void open(int pTypeID, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_types WHERE TypeID = " +  pTypeID.ToString() ;
			DataTable Tbl = pConn.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "TypeID = " +  pTypeID.ToString() );
		}
		
		public bool openExist(int pTypeID) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_types WHERE TypeID = " +  pTypeID.ToString() ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1){
				this.BindData(Tbl.Rows[0]);
				return true;
			}else
				return false;
		}
		
		public bool openExist(int pTypeID, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods_types WHERE TypeID = " +  pTypeID.ToString() ;
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
			SqlStr = "INSERT INTO goods_types(TypeName, CreateTime, CreateBy, UpdateTime, UpdateBy) VALUES(" + 
				DbMgr.formatDbString(_TypeName)  + 
				", " + DbMgr.formatDbDateTime(_CreateTime) +
				", " + DbMgr.formatDbID(_CreateBy) + 
				", " + DbMgr.formatDbDateTime(_UpdateTime) +
				", " + DbMgr.formatDbID(_UpdateBy) + 
				")";
			result = pConn.exeInsertQuery(SqlStr,"goods_types","TypeID");
			_TypeID = result;
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
			SqlStr = " UPDATE goods_types SET " + 
				" TypeName = " + DbMgr.formatDbString(_TypeName) + 
				" ,UpdateTime = " + DbMgr.formatDbDateTime(_UpdateTime) + 
				" ,UpdateBy = " + DbMgr.formatDbID(_UpdateBy) + 
				" WHERE TypeID = " +  _TypeID.ToString() ;
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
			SqlStr = " DELETE FROM goods_types" + 
				" WHERE TypeID = " +  _TypeID.ToString() ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}
		#endregion
		
		#region Manual Code

		#endregion
	}
}
