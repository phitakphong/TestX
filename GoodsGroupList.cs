using System;
using System.Data;
using System.Collections;
using System.Text;
using Phitakphong.LEKCommon;
using Phitakphong.LEKDbMgr;

namespace Phitakphong.Makeup.Common {
	/// <summary>
	/// List class for GoodsGroup.
	/// </summary>
 	public class GoodsGroupList {

		#region DataMembers
		private DataTable _Tbl;
		private enumListOpenType _Mode;
		private string _WhereStr;
		#endregion

		#region Constructor
		public GoodsGroupList() {
			_Mode = enumListOpenType.Active;
		}
		
		public GoodsGroupList(enumListOpenType pOpenType) {
			_Mode = pOpenType;
		}		
		#endregion

		#region Properties
		public DataTable Table {
			get{
				if (this._Tbl == null)
					this.open();
				return _Tbl;
			}
		}

		public int Count {
			get{
				if (this._Tbl == null)
					this.open();
				return _Tbl.Rows.Count;
			}
		}
		
		public enumListOpenType OpenMode {
			get{
				return _Mode;
			}
			set{
				_Mode = value;
				switch(_Mode){
					case enumListOpenType.All:
						_WhereStr = " WHERE 2 > 1 ";
						break;
					case enumListOpenType.Active:
						_WhereStr = " WHERE IsActive = 'Y'";
						break;
					case enumListOpenType.NonActive:
						_WhereStr = " WHERE IsActive = 'N'";
						break;
				}
			}
		}
		#endregion

		#region Method
		public DataTable open() {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ _WhereStr 
				+ " ORDER BY GroupID ";
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(IConnection pConn) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ _WhereStr 
				+ " ORDER BY GroupID ";
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}
		
		public DataTable open(string pSortBy) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ _WhereStr 
				+ " ORDER BY " + pSortBy;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSortBy, IConnection pConn) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ _WhereStr 
				+ " ORDER BY " + pSortBy;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}	
			
		public DataTable open(string pSearchBy, string pCriteria) {
			string SqlStr;
			string WhereStr = _WhereStr;
			if (pCriteria.Length > 0)
				WhereStr = " AND " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ WhereStr;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSearchBy, string pCriteria, IConnection pConn) {
			string SqlStr;
			string WhereStr = _WhereStr;
			if (pCriteria.Length > 0)
				WhereStr = " AND " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ WhereStr;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}		
		
		public DataTable open(string pSearchBy, string pCriteria, string pSortBy) {
			string SqlStr;
			string WhereStr = _WhereStr;
			if (pCriteria.Length > 0)
				WhereStr = " AND " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ WhereStr
				+ " ORDER BY " + pSortBy;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSearchBy, string pCriteria, string pSortBy, IConnection pConn) {
			string SqlStr;
			string WhereStr = _WhereStr;
			if (pCriteria.Length > 0)
				WhereStr = " AND " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_groups"
				+ WhereStr
				+ " ORDER BY " + pSortBy;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}	
		
		public static DataTable open4Cbo(string pTextFiled, string pValueFiled, string pAllText) {
			string SqlStr;
			SqlStr = "SELECT " + pTextFiled + ", " + pValueFiled 
				+ " FROM goods_groups"
				+ " WHERE IsActive = 'Y' "
				+ " ORDER BY " + pTextFiled;
			DataTable tbl =  DbMgr.exeQuery(SqlStr);
			DataRow row = tbl.NewRow();
			row[pValueFiled] = 0;
			row[pTextFiled] = pAllText + "...";
			tbl.Rows.InsertAt(row,0);
			return tbl;
		}
		
		public static DataTable open4Cbo(string pTextFiled, string pValueFiled) {
			string SqlStr;
			SqlStr = "SELECT " + pTextFiled + ", " + pValueFiled 
				+ " FROM goods_groups"
				+ " WHERE IsActive = 'Y' "
				+ " ORDER BY " + pTextFiled;
			return DbMgr.exeQuery(SqlStr);
		}				
		#endregion

		#region Indexer
		public GoodsGroup this[int index]{
			get{
				if (this._Tbl == null)
					this.open();
				if (index < this._Tbl.Rows.Count){
					GoodsGroup obj = new GoodsGroup();
					obj.BindData(_Tbl.Rows[index]);
					return obj;
				}else
					return null;
			}
		}			
		#endregion
		
		#region Manual Code

		#endregion		
	}

}
