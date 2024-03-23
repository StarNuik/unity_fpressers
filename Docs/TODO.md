# ITER
[] room gltf import
[] club / correct ending
	[] level design
		[] instruments
		[] confetti / trash on the floor
		[x] room layout
	[] crunch textures
	[] cutscene: включается после порога
		камерой влетает к сцене
	[x] move assets to the Art/3d folder
[] phone / reverse ending
	[] cutscene / separate scene w/ the sfx?
[] bed cutscene
	[] longer female sample
[] playtest
	[] "press f to interact" every time
	[] "WASD" -> "WASD keys"
	[] "mouse to look around"

# TWEAKS BACKLOG
[x] splash
	[x] language selection (splash)
	[x] remove logo from 3d poster -> move to splash ui
	[x] start hint -> 0.5 sec delay
[x] pc cutscene
	[x] pc di logo - +1-2 secs
	[x] overall add a +1 sec to every pc screen?
[x] remove all height maps
[x] intro cutscene
	[x] убрать hold в начале

# TBD

## polish iter
[] performance
[] graphics cringe
	[] light / shadow leaks (shadow maps)

## mobile iter
[] text size
[] joystick
[] tap to interact
[] rotate phone into horizontal

# INFO

## ideas
[] "press f to restart"
[] clutter disappearance
		[] make a movie w/ an empty-ish room
			[] mb add disappearance in the timeline
[] после последнего взаимодействия включить песню на месте с временем ровно до концовки
	[] на последнем действии музыка затихает
[] на постер приближение сделать подпев
[] performance ideas
[DENY] молоко
	[] твик vfx
	[] исчезновение цели взаимодействия
	

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

## v3
[x] build size
	[] do smth about meshes, if willing
	[x] remove all ao, height (?!) maps
	[x] remove most metallic maps, try to remove normal maps
	[x] downres, crunch and cringe all textures as much as possible
[x] performance
	[x] test light bake [>>1.5h]
		* it works, but doesn't improve the performance that much
	[x] replace URP/Lit w/ URP/Simple Lit
		* tested on a test scene, didn't seem to improve performance that much
	[x] win laptop: windows -> graphics perforamnce -> firefox -> high performance
[x] game restart
	[x] restart state fix
[PART] graphics cringe
	[x] door wall scale
	[x] bed / plinthus fog interaction