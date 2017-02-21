---
layout: grid
title: Teaching, Learning and Making Resources
permalink: index.html
kind: grid

---

Resources for tutors and students.

<ul class="grid {{ page.kind }}  three"> <!-- the class 'three' adjusts the width to centre the blocks -->
  <li class="teach" style="background: white url('{{ "/assets/tile.png" | absolute_url }}') no-repeat top center;">
    <a href="{{ site.baseurl }}{% link teaching.md %}" class="a"></a>
    <div class="text">
      <a href="{{ site.baseurl }}{% link teaching.md %}">
        <div class="inner">
          <h3>Teaching</h3>
          <p class="excerpt">All teaching resources</p>
        </div>
      </a>
    </div>
</li>

<li class="learn" style="background: white url('{{ "/assets/tile.png" | absolute_url }}') no-repeat top center;">
  <a href="{{ site.baseurl }}{% link learning.md %}" class="a"></a>
  <div class="text">
    <a href="{{ site.baseurl }}{% link learning.md %}">
      <div class="inner">
        <h3>Learning</h3>
        <p class="excerpt">All learning resources</p>
      </div>
    </a>
  </div>
</li>
					
<li class="make" style="background: white url('{{ "/assets/tile.png" | absolute_url }}') no-repeat top center;">
  <a href="{{ site.baseurl }}{% link making.md %}" class="a"></a>
  <div class="text">
    <a href="{{ site.baseurl }}{% link making.md %}">
      <div class="inner">
        <h3>Making</h3>
        <p class="excerpt">All making and project resources</p>
      </div>
    </a>
  </div>
  </li>
</ul>

<div style="clear:both;"></div>
