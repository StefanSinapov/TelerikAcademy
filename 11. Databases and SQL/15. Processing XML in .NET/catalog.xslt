<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />

    <xsl:template match="/">
        <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt; </xsl:text>
        <html>
            <body>
                <h2>Catalog!</h2>
                <ul>
                    <xsl:for-each select="albums/album">
                        <li>Album
                            <ul>
                                <li>
                                    <strong>Name: </strong>
                                    <xsl:value-of select="name"/>
                                </li>
                                <li>
                                    <strong>Artist: </strong>
                                    <xsl:value-of select="artist"/>
                                </li>
                                <li>
                                    <strong>Year: </strong>
                                    <xsl:value-of select="year"/>
                                </li>
                                <li>
                                    <strong>Producer: </strong>
                                    <xsl:value-of select="producer"/>
                                </li>
                                <li>
                                    <strong>Price: </strong>
                                    <xsl:value-of select="price"/>
                                </li>
                                <li>
                                    <strong>Songs: </strong>
                                    <xsl:for-each select="songs/song">
                                        <ul>
                                            <li>
                                                <xsl:value-of select="title"/>: 
                                                <xsl:value-of select="duration"/>
                                            </li>
                                        </ul>
                                    </xsl:for-each>
                                </li>
                            </ul>
                        </li>
                    </xsl:for-each>
                </ul>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>
