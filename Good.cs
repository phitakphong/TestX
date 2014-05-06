using System;
using System.Data;
using System.Collections;
using System.Text;
using Phitakphong.LEKCommon;
using Phitakphong.LEKDbMgr;

namespace Phitakphong.Makeup.Common {
	/// <summary>
	/// Entity class for Good.
	/// </summary>
 	public class Good : ILEKEntity {

		#region DataMembers
		private string _GoodsCode;
		private string _OldGoodsCode;
		private string _GoodsName;
		private string _GoodsDesc;
		private string _GoodsPcs;
		private decimal _Price;
		private int _Qty;
		private string _GoodsIMG;
		private int _GroupID;
		private GoodsGroup _group;
		private DateTime _CreateTime;
		private int _CreateBy;
		private DateTime _UpdateTime;
		private int _UpdateBy;

		#endregion

		#region Constructor
		public Good() {
		}

		public Good(string pGoodsCode) {
			this.open(pGoodsCode);
		}
		
		public Good(string pGoodsCode, IConnection pConn) {
			this.open(pGoodsCode, pConn);
		}
		#endregion

		#region Properties
		public string GoodsCode{
			get {
				return _GoodsCode;
			}
			set {
				_GoodsCode= value;
			}
		}

		public string GoodsName{
			get {
				return _GoodsName;
			}
			set {
				_GoodsName= value;
			}
		}

		public string GoodsDesc{
			get {
				return _GoodsDesc;
			}
			set {
				_GoodsDesc= value;
			}
		}

		public string GoodsPcs{
			get {
				return _GoodsPcs;
			}
			set {
				_GoodsPcs= value;
			}
		}

		public decimal Price{
					get {
				return _Price;
			}
			set {
				_Price= value;
			}
		}

		public int Qty{
			get {
				return _Qty;
			}
			set {
				_Qty = value;
			}
		}

		public string GoodsIMG{
			get {
				return _GoodsIMG;
			}
			set {
				_GoodsIMG= value;
			}
		}

		public GoodsGroup group{
			get {
				if (_group==null){
					if (_GroupID == 0)
						return null;
					_group = new GoodsGroup(_GroupID);
				}
				return _group;
			}
			set {
				_group = value;
				_GroupID = _group.GroupID;
			}
		}

		public int GroupID{
			set {
				_GroupID = value;
				_group = null;
			}
			get {
				return _GroupID;
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
			_GoodsCode = LEKConvert.ToString(pRow["GoodsCode"]);
			_OldGoodsCode = LEKConvert.ToString(pRow["GoodsCode"]);
			_GoodsName = LEKConvert.ToString(pRow["GoodsName"]);
			_GoodsDesc = LEKConvert.ToString(pRow["GoodsDesc"]);
			_GoodsPcs = LEKConvert.ToString(pRow["GoodsPcs"]);
			_Price = LEKConvert.ToDecimal(pRow["Price"]);
			_Qty = LEKConvert.ToInt(pRow["Qty"]);
			_GoodsIMG = LEKConvert.ToString(pRow["GoodsIMG"]);
			_GroupID = LEKConvert.ToInt(pRow["GroupID"]);
			_CreateTime = LEKConvert.ToDateTime(pRow["CreateTime"]);
			_CreateBy = LEKConvert.ToInt(pRow["CreateBy"]);
			_UpdateTime = LEKConvert.ToDateTime(pRow["UpdateTime"]);
			_UpdateBy = LEKConvert.ToInt(pRow["UpdateBy"]);

		}

		public void open(string pGoodsCode) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods WHERE GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) );
		}

		public void open(string pGoodsCode, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods WHERE GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) ;
			DataTable Tbl = pConn.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1)
				this.BindData(Tbl.Rows[0]);
			else
				throw new LEKException(113, "Not found object {0}", "GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) );
		}
		
		public bool openExist(string pGoodsCode) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods WHERE GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) ;
			DataTable Tbl = DbMgr.exeQuery(SqlStr);
			if (Tbl.Rows.Count == 1){
				this.BindData(Tbl.Rows[0]);
				return true;
			}else
				return false;
		}
		
		public bool openExist(string pGoodsCode, IConnection pConn) {
			string SqlStr;
			SqlStr = " SELECT * FROM goods WHERE GoodsCode = " +  DbMgr.formatDbString(pGoodsCode) ;
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
			SqlStr = "INSERT INTO goods(GoodsCode, GoodsName, GoodsDesc, GoodsPcs, Price, Qty, GoodsIMG, GroupID, CreateTime, CreateBy, UpdateTime, UpdateBy) VALUES(" + 
				DbMgr.formatDbString(_GoodsCode)  + 
				", " + DbMgr.formatDbString(_GoodsName)  + 
				", " + DbMgr.formatDbString(_GoodsDesc)  + 
				", " + DbMgr.formatDbString(_GoodsPcs)  + 
				", " + DbMgr.formatDbDecimal(_Price)  + 
				", " + _Qty.ToString()  + 
				", " + DbMgr.formatDbString(_GoodsIMG)  + 
				", " + DbMgr.formatDbID(_GroupID) + 
				", " + DbMgr.formatDbDateTime(_CreateTime) +
				", " + DbMgr.formatDbID(_CreateBy) + 
				", " + DbMgr.formatDbDateTime(_UpdateTime) +
				", " + DbMgr.formatDbID(_UpdateBy) + 
				")";
			result = pConn.exeNonQuery(SqlStr);
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
			SqlStr = " UPDATE goods SET " + 
				" GoodsCode = " + DbMgr.formatDbString(_GoodsCode) + 
				" ,GoodsName = " + DbMgr.formatDbString(_GoodsName) + 
				" ,GoodsDesc = " + DbMgr.formatDbString(_GoodsDesc) + 
				" ,GoodsPcs = " + DbMgr.formatDbString(_GoodsPcs) + 
				" ,Price = " + _Price.ToString() + 
				" ,Qty = " + _Qty.ToString() + 
				" ,GoodsIMG = " + DbMgr.formatDbString(_GoodsIMG) + 
				" ,GroupID = " + DbMgr.formatDbID(_GroupID) + 
				" ,UpdateTime = " + DbMgr.formatDbDateTime(_UpdateTime) + 
				" ,UpdateBy = " + DbMgr.formatDbID(_UpdateBy) + 
				" WHERE GoodsCode = " +  DbMgr.formatDbString(_OldGoodsCode) ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}
		
		public int delete() {
			string SqlStr;
			int result=0;
			SqlStr = " DELETE FROM goods" + 
				" WHERE GoodsCode = " +  DbMgr.formatDbString(_OldGoodsCode) ;
			result = DbMgr.exeNonQuery(SqlStr);
			return result;
		}
		
		public int delete(IConnection pConn) {
			string SqlStr;
			int result=0;
			SqlStr = " DELETE FROM goods" + 
				" WHERE GoodsCode = " +  DbMgr.formatDbString(_OldGoodsCode) ;
			result = pConn.exeNonQuery(SqlStr);
			return result;
		}
		#endregion
		
		#region Manual Code

		#endregion
	}
}
