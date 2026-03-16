import { Grid, IconButton, InputAdornment, TextField } from '@mui/material'
import { Paperclip as PaperclipIcon, Send as SendIcon } from 'react-feather'

const Chat = () => {
  return (
    <Grid
      container
      direction="column"
      alignItems="center"
      justifyContent="center"
    >
      <Grid size={{ xs: 12, md: 8 }}>
        <TextField
          fullWidth
          placeholder="Como posso ajudar?"
          variant="outlined"
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <IconButton
                    sx={{
                      color: 'rgba(255, 255, 255, 0.7)',
                      '&:hover': { color: 'rgba(255, 255, 255, 1)' },
                    }}
                    onClick={() => console.log('Anexar arquivo')}
                  >
                    <PaperclipIcon />
                  </IconButton>
                </InputAdornment>
              ),
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton
                    sx={{
                      color: 'rgba(255, 255, 255, 0.7)',
                      '&:hover': { color: 'rgba(255, 255, 255, 1)' },
                    }}
                    onClick={() => console.log('Enviar mensagem')}
                  >
                    <SendIcon />
                  </IconButton>
                </InputAdornment>
              ),
              sx: {
                color: '#ffffff',
                borderRadius: '12px',
                backgroundColor: 'rgba(255, 255, 255, 0.05)',
                borderColor: 'rgba(255, 255, 255, 0.4)',
                '& .MuiOutlinedInput-notchedOutline, &:hover .MuiOutlinedInput-notchedOutline':
                  {
                    borderColor: '#3F3F3F',
                    borderWidth: '1px',
                    transition: 'border-color 0.3s',
                  },
                '&.Mui-focused .MuiOutlinedInput-notchedOutline': {
                  borderColor: 'rgba(255, 255, 255, 0.6)',
                  borderWidth: '1px',
                },
              },
            },
          }}
        />
      </Grid>
    </Grid>
  )
}

export default Chat
