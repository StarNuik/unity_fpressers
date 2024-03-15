# ITER
## v2
[x] splash screen [1.5h>>3h]
	[x] white fade in
	[x] "press f to start"
	[] poster (i forgot what this point is about)

[] sfx [3-6h] [blocked]
	[x] footsteps [>>1h]
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
		[] the bed is boring
		[] shorter?
	[] outro -> -5 sec
	[] cigs -> bigger collider
[] outline [1.5h]
	[] suppress outline in cutscenes
	[] outline flicker bug fix
[] mouse sens x0.5 [0h]
[] game restart
	[] "press f to restart"
[] fog / milk [3h] [blocked]
	[x] turn off free roam fog
	[] clutter disappearance
[] performance ideas
	[x] test light bake [>>1.5h]
		* it works, but doesn't improve the performance that much
	[] replace URP/Lit w/ URP/Simple Lit
[x] screen text [3-6h>>4h] [blocked]
	[x] ending tracker [3h>>1.5h]
	[x] in game font
	[x] show "wasd to move" - until moved 1 unit
	[x] show "f to interact" - on first raycast
	[x] inner monologue
		[x] (cutscene sends an event to TURN ON the text for x secs)
		[x] good / bad outcome text
[x] new room clutter [3h>>3h+]
	[x] ceiling plinthuses
	[x] vinyl record rotation
	[x] skateboard
	[x] fpressers stuff
	[x] ukulele
	[x] pen & notebook
	[x] pillows
	[x] vinyl records
		[x] di record
[x] webgl loader mechanism [1.5h>>0.5h]
	[x] посмотреть как работает
	[x] статья на хабре

### blocked by
[] sfx
[] text
	[] font
[] clutter disappearance order
[] intro poster

# TBD

## polish iter
[] build size
	[] remove all ao, height (?!) maps
	[] remove most metallic maps, try to remove normal maps
	[] downres, crunch and cringe all textures as much as possible
	[] do smth about meshes, if willing
[] performance
[] graphics cringe
	[] shadows leak
	[] bed / plinthus fog interaction
	[] door wall scale

## mobile iter
[] text size
[] joystick
[] tap to interact
[] rotate phone into horizontal

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