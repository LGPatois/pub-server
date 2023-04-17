Attachment::AddBefore("Player::onDamage",	"HitSounds::OnDamage");

function HitSounds::OnDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
	if (%object.hitSoundsDisabled || %type == 0)
		return;
	
	%damagedClient = Player::getClient(%this);
	
	// Team damage not on self
	if (%object != %damagedClient) {
		
		%damagedClientTeam = Client::getTeam(%damagedClient);
		%shooterClientTeam = Client::getTeam(%object);
			
		if(%shooterClientTeam != %damagedClientTeam)
			// maybe do a local sound instead of a message?
			Client::sendMessage(%object, 0, "~C_BuySell.wav");
	}
}

