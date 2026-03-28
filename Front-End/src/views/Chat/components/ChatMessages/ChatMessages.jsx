import { Box, Typography } from '@mui/material'

const ChatMessages = ({ chatHistory }) => {
  return (
    <>
      {chatHistory.map((msg, index) => {
        const isUser = msg.role === 'user'
        const isComponent =
          typeof msg.content === 'object' && msg.content !== null

        return (
          <Box
            key={index}
            sx={{
              alignSelf: isUser ? 'flex-end' : 'flex-start',
              backgroundColor: isUser ? '#2563eb' : 'rgba(255, 255, 255, 0.05)',
              color: '#fff',
              p: isComponent ? 1 : 2,
              borderRadius: isUser ? '15px 15px 0 15px' : '15px 15px 15px 0',
              maxWidth: isComponent ? '100%' : '75%',
              width: isComponent ? '100%' : 'auto',
              border: isUser ? 'none' : '1px solid #3F3F3F',
              boxShadow: isComponent ? '0 4px 12px rgba(0,0,0,0.3)' : 'none',
            }}
          >
            {isComponent ? (
              <Box sx={{ minWidth: { xs: '280px', md: '500px' } }}>
                {msg.content}
              </Box>
            ) : (
              <Typography variant="body1">{msg.content}</Typography>
            )}
          </Box>
        )
      })}
    </>
  )
}

export default ChatMessages
