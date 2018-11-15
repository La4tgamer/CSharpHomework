<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/ArrayOfOrder">
		<html>
			<head>
				<title>Order List</title>
			</head>
			<body>
        <xsl:for-each select="Order">
          <ul>
            <li>
              <p align ="center">
                客户姓名 <xsl:value-of select="Customer" /> 订单ID <xsl:value-of select="OrderID" />
              </p>
              <table border ="1" align ="center">
                <xsl:for-each select="Items">
                  <tr>
                    <td>商品名称</td>
                    <td>商品数量</td>
                    <td>商品单价</td>
                  </tr>
                  <xsl:for-each select="OrderDetails">
                    <tr>
                      <td>
                        <xsl:value-of select="ProductName" />
                      </td>
                      <td>
                        <xsl:value-of select="ProductNum" />
                      </td>
                      <td>
                        <xsl:value-of select="ProductPrice" />
                      </td>
                    </tr>
                  </xsl:for-each>
                </xsl:for-each>
              </table>
              <p align ="center">订单总金额 <xsl:value-of select="TotalMoney" /></p>
            </li>
            
          </ul>
          
        </xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>