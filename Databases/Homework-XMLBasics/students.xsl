<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1 style="color: #00ff21; text-align: center">Students</h1>
        <xsl:for-each select="/students/student">
          <h2>Student:</h2>
          <ul>
            <li>
              <span>Name: </span>
              <xsl:value-of select="name"/>
            </li>
            <li>
              <span>Sex: </span>
              <xsl:value-of select="sex"/>
            </li>
            <li>
              <span>Birth date: </span>
              <xsl:value-of select="birthDate"/>
            </li>
            <li>
              <span>Phone: </span>
              <xsl:value-of select="phone"/>
            </li>
            <li>
              <span>E-mail: </span>
              <xsl:value-of select="email"/>
            </li>
            <li>
              <span>Course: </span>
              <xsl:value-of select="course"/>
            </li>
            <li>
              <span>Specialty: </span>
              <xsl:value-of select="specialty"/>
            </li>
            <li>
              <span>Faculty number: </span>
              <xsl:value-of select="facultyNumber"/>
            </li>
            <li>
              <span>Exams taken: </span>
              <xsl:for-each select="examsTaken/exam">
                <ul>
                  <span>Exam: </span>
                  <li>
                    <span>Name: </span>
                    <xsl:value-of select="name"/>
                  </li>
                  <li>
                    <span>Tutor: </span>
                    <xsl:value-of select="tutor"/>
                  </li>
                  <li>
                    <span>Score: </span>
                    <xsl:value-of select="score"/>
                  </li>
                </ul>
              </xsl:for-each>
            </li>
            <li>
              <span>Enrollment: </span>
              <ul>
                <li>
                  <span>Date:</span>
                  <xsl:value-of select="enrollment/date"/>
                </li>
                <li>
                  <span>Exam Score</span>
                  <xsl:value-of select="enrollment/examScore"/>
                </li>
              </ul>
            </li>
            <li>
              <span>Teacher endorsments: </span>
              <xsl:value-of select="endorsements"/>
            </li>
          </ul>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>