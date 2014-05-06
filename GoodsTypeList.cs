using System;
using System.Data;
using System.Collections;
using System.Text;
using Phitakphong.LEKCommon;
using Phitakphong.LEKDbMgr;

namespace Phitakphong.Makeup.Common {
	/// <summary>
	/// List class for GoodsType.
	/// </summary>
 	public class GoodsTypeList {

		#region DataMembers
		private DataTable _Tbl;
		#endregion

		#region Constructor
		public GoodsTypeList() {
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
		#endregion

		#region Method
		public DataTable open() {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ " ORDER BY TypeID ";
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(IConnection pConn) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ " ORDER BY TypeID ";
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}
		
		public DataTable open(string pSortBy) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ " ORDER BY " + pSortBy;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSortBy, IConnection pConn) {
			string SqlStr;
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ " ORDER BY " + pSortBy;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}	
			
		public DataTable open(string pSearchBy, string pCriteria) {
			string SqlStr;
			string WhereStr = "";
			if (pCriteria.Length > 0)
				WhereStr = " WHERE " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ WhereStr;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSearchBy, string pCriteria, IConnection pConn) {
			string SqlStr;
			string WhereStr = "";
			if (pCriteria.Length > 0)
				WhereStr = " WHERE " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ WhereStr;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}	
		
		public DataTable open(string pSearchBy, string pCriteria, string pSortBy) {
			string SqlStr;
			string WhereStr = "";
			if (pCriteria.Length > 0)
				WhereStr = " WHERE " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ WhereStr
				+ " ORDER BY " + pSortBy;
			_Tbl =  DbMgr.exeQuery(SqlStr);
			return _Tbl;
		}

		public DataTable open(string pSearchBy, string pCriteria, string pSortBy, IConnection pConn) {
			string SqlStr;
			string WhereStr = "";
			if (pCriteria.Length > 0)
				WhereStr = " WHERE " + pSearchBy + DbMgr.formatDbPatialSearchString(pCriteria);
			SqlStr = "SELECT * "
				+ " FROM goods_types"
				+ WhereStr
				+ " ORDER BY " + pSortBy;
			_Tbl =  pConn.exeQuery(SqlStr);
			return _Tbl;
		}	
		
		public static DataTable open4Cbo(string pTextFiled, string pValueFiled, string pAllText) {
			string SqlStr;
			SqlStr = "SELECT " + pTextFiled + ", " + pValueFiled 
				+ " FROM goods_types"
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
				+ " FROM goods_types"
				+ " ORDER BY " + pTextFiled;
			return DbMgr.exeQuery(SqlStr);
		}				
		#endregion

		#region Indexer
		public GoodsType this[int index]{
			get{
				if (this._Tbl == null)
					this.open();
				if (index < this._Tbl.Rows.Count){
					GoodsType obj = new GoodsType();
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
