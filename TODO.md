# ITER
## v2
[] test light bake [3h]
[] webgl loader mechanism [1.5h]
	[] посмотреть как работает
	[] статья на хабре
[] new room clutter [3h]
	[] skateboard
	[] fpressers stuff
	[] ukulele
	[] ceiling plinthuses
	[] pen & notebook
	[] pillows
[] sfx [3-6h] [blocked]
	[] footsteps
	[] room ambient
	[] cigs
		[] пачка сигарет
		[] зажигалка
		[] вдох / выдох, длинный (2s)
	[] кровать
		[] лечь на кровать
		[] встать с кровати
	[] poster
		[] бумага
	[] window
		[] outside sfx
	[] pc
		[] кнопка
		[] раскрутка пк / диска
		[] монитор
		[] глюки
[] interactions [3-6h]
	[] pc fix
	[] bed interaction improvement
		[] shorter?
	[] the bed is boring
	[] outro -> -5 sec
	[] cigs -> bigger collider
[] fog / milk [3h] [blocked]
	[] turn off free roam fog
	[] clutter disappearance
[] screen text [3-6h] [blocked]
	[] ending tracker [3h]
	[] in game font
	[] show "wasd to move" - until moved 1 unit
	[] show "f to interact" - on first raycast
	[] inner monologue
		[] (cutscene sends an event to TURN ON the text for x secs)
		[] good / bad outcome text
[] splash screen [1.5h]
	[] white fade in
	[] "press f to (re)start"
	[] poster
[] outline [1.5h]
	[] suppress outline in cutscene
	[] outline flicker bug fix
[] mouse sens x0.5 [0h]

### blocked by
[] sfx
[] text
[] clutter disappearance order
[] intro poster

# TBD

## polish iter
[] build size
[] performance
[] graphics cringe
	[] shadows leak
	[] bed / plinthus fog interaction
	[] door wall scale

## mobile iter
[] text size
[] joystick
[] tap to interact

# INFO

## ideas
* после последнего взаимодействия включить песню на месте с временем ровно до концовки
	* на последнем действии музыка затихает
* молоко
	1. исчезновение предметов не важных
	2. твик vfx
	3. исчезновение цели взаимодействия
* на постер приближение сделать подпев

## approx timeline
5:25 (mb 5:00, so that theres stuff to fade out to)
	0:30 intro
	1:00 walking around, looking for stuff
	0:30 x5 interactions
	0:30 outro
	__________
	4:30 total

# COMPLETE
## v1
[x] room
	[x] lighting
	[x] fixes (floor, walls, lamp, cigs, books?, the door)
[x] Interactions
	[x] Bed
	[x] Window
	[x] Poster
	[x] Cigarettes
	[x] PC
[x] Neutral ending