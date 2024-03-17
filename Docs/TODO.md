# ITER

# TBD

## v3 iter
[] game restart
	[] "press f to restart"
[] clutter disappearance

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
[] performance ideas
	[x] test light bake [>>1.5h]
		* it works, but doesn't improve the performance that much
	[] replace URP/Lit w/ URP/Simple Lit

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

## v2
[x] splash screen [1.5h>>3h]
	[x] white fade in
	[x] "press f to start"
	[] poster (i forgot what this point was about)
[x] sfx [3-6h] [blocked]
	[x] footsteps [>>1h]
	[x] room ambient
	[x] cigs
		[x] пачка сигарет
		[x] зажигалка
		[x] вдох / выдох, длинный (2s)
	[x] кровать
		[x] лечь на кровать
		[x] встать с кровати
	[x] poster
		[x] бумага
	[x] window
		[x] outside sfx
	[x] pc
		[x] кнопка
		[x] раскрутка пк / диска
		[deny] монитор
		[x] глюки
[x] interactions [3-6h]
	[x] pc fix
	[x] bed interaction improvement
	[i tweaked the ending but not sure that the issue got resolved] outro -> -5 sec
	[x] cigs -> bigger collider
[x] outline [1.5h]
	[x] suppress outline in cutscenes
	[ignore] outline flicker bug fix
[x] fog / milk
	[x] turn off free roam fog
[x] mouse sens x0.5 [0h]
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