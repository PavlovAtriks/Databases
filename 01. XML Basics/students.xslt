<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns="http://www.w3.org/1999/xhtml"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:students="urn:students">
   

    <xsl:template match="/">
      <html>
        <head>
          <title>Students</title>
        </head>
        <body>
          <table>
            <tr>
              <th>Name</th>
              <th>Sex</th>
              <th>Birth date</th>
              <th>Phone</th>
              <th>E-mail</th>
              <th>Course</th>
              <th>Specialty</th>
              <th>Faculty nimber</th>
              <th>Exams</th>
            </tr>
            <xsl:for-each select="students:students/students:student">
              <tr>
                <td>
                  <xsl:value-of select="students:name"/>
                </td>
                <td>
                  <xsl:value-of select="students:sex"/>
                </td>
                <td>
                  <xsl:value-of select="students:birthDate"/>
                </td>
                <td>
                  <xsl:value-of select="students:phone"/>
                </td>
                <td>
                  <xsl:value-of select="students:email"/>
                </td>
                <td>
                  <xsl:value-of select="students:course"/>
                </td>
                <td>
                  <xsl:value-of select="students:specialty"/>
                </td>
                <td>
                  <xsl:value-of select="students:facultyNumber"/>
                </td>
                <td>
                  <xsl:for-each select="students:exams/students:exam">
                    <div>
                      <em>
                        <xsl:value-of select="students:name"/>
                      </em>/
                      tutor:<xsl:value-of select="students:tutor"/>/
                      score:<xsl:value-of select="students:score"/>
                    </div>
                  </xsl:for-each>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
