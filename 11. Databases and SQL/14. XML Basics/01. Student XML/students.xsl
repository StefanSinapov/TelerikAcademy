<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Students</h1>
  <ul>
	<xsl:for-each select="students/student">
	  <li>
		<xls:value-of select="name"/>
		<ul>
			<li><xls:value-of select="sex"/></li>
			<li><xls:value-of select="birth-date"/></li>
			<li><xls:value-of select="phone"/></li>
			<li><xls:value-of select="email"/></li>
			<li><xls:value-of select="course"/></li>
			<li>
				<ul>
					<xls:for-each select="students/student/course">
						<li><xls:value-of select="name"/></li>
						<li><xls:value-of select="tutor"/></li>
						<li><xls:value-of select="score"/></li>
					</xls:for-each>
				</ul>
			</li>
		</ul>
	  </li>
	</xsl:for-each>
  </ul>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
