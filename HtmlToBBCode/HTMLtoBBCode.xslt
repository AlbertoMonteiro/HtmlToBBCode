<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- XSLT 1.0 stylesheet to convert a subset of XHTML to BBCode. Supports both some legacy presentational elements and CSS in style attributes. External CSS stylesheets or CSS in <style> elements are not supported. If you need that you can probably run the markup through a CSS pre-processor first. Only font sizes in pt and px are supported. -->
<!-- Released into the Public Domain. The code is so trivial it probably cannot be copyrighted anyway. -->
<!-- TODO: Add support for headings. Better handling of font sizes. -->

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="text" indent='no'/>
	<xsl:strip-space  elements="*"/>

	<xsl:template match="/">
		<xsl:apply-templates/>
	</xsl:template>

	<xsl:template match='b'>[b]<xsl:apply-templates/>[/b]</xsl:template>
	<xsl:template match='strong'>[b]<xsl:apply-templates/>[/b]</xsl:template>
	<xsl:template match='i'>[i]<xsl:apply-templates/>[/i]</xsl:template>
	<xsl:template match='em'>[i]<xsl:apply-templates/>[/i]</xsl:template>
	<xsl:template match='u'>[u]<xsl:apply-templates/>[/u]</xsl:template>
	<xsl:template match='del'>[s]<xsl:apply-templates/>[/s]</xsl:template>
	<xsl:template match='center'>[center]<xsl:apply-templates/>[/center]</xsl:template>
	<xsl:template match='blockquote'>[quote]<xsl:apply-templates/>[/quote]</xsl:template>
	<xsl:template match='a'>[url=<xsl:value-of select='@href'/>]<xsl:apply-templates/>[/url]</xsl:template>
	<xsl:template match='img'>[center][img]<xsl:value-of select='@src'/><xsl:apply-templates/>[/img][/center]</xsl:template>
	<xsl:template match='ul'>[ul]<xsl:apply-templates/>[/ul]</xsl:template>
	<xsl:template match='ol'>[ol]<xsl:apply-templates/>[/ol]</xsl:template>
	<xsl:template match='li'>[li]<xsl:apply-templates/>[/li]</xsl:template>
	<xsl:template match='code'>[code]<xsl:apply-templates/>[/code]</xsl:template>
	<xsl:template match='table'>[table]<xsl:apply-templates/>[/table]</xsl:template>
	<xsl:template match='tr'>[tr]<xsl:apply-templates/>[/tr]</xsl:template>
	<xsl:template match='th'>[th]<xsl:apply-templates/>[/th]</xsl:template>
	<xsl:template match='td'>[td]<xsl:apply-templates/>[/td]</xsl:template>
	<xsl:template match='font'><xsl:if test='@color'>[color=<xsl:value-of select='@color'/>]</xsl:if><xsl:if test='@size'>[size=<xsl:value-of select='@size'/>]</xsl:if><xsl:apply-templates/><xsl:if test='@size'>[/size]</xsl:if><xsl:if test='@color'>[/color]</xsl:if></xsl:template>

	<!-- Handle arbitrary element with CSS styling -->
	<xsl:template match='*[@style]'>
		<xsl:variable name='style' select='concat(translate(@style," ",""),";")'/>
		<xsl:if test='contains($style,"font-style:italic")'>[i]</xsl:if>
		<xsl:if test='contains($style,"font-weight:bold")'>[b]</xsl:if>
		<xsl:if test='contains($style,"color:")'>[color=<xsl:value-of select='substring-before(substring-after(@style,"color:"),";")'/>]</xsl:if>
		<!-- Either px or pt. Todo: Better handling of errors. -->
		<xsl:if test='contains($style,"font-size:")'>[size=<xsl:value-of select='substring-before(substring-after($style,"font-size:"),"px")'/><xsl:value-of select='substring-before(substring-after($style,"font-size:"),"pt")'/>]</xsl:if>
		<xsl:apply-templates/>
		<xsl:if test='contains($style,"font-size:")'>[/size]</xsl:if>
		<xsl:if test='contains($style,"color:")'>[/color]</xsl:if>
		<xsl:if test='contains($style,"font-weight:bold")'>[/b]</xsl:if>
		<xsl:if test='contains($style,"font-style:italic")'>[/i]</xsl:if>
	</xsl:template>
	<xsl:template match='br'><xsl:text>&#x0a;</xsl:text></xsl:template>
</xsl:stylesheet>
